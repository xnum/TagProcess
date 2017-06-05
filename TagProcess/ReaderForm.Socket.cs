using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TagProcess
{
    public  class Cmd
    {
        public enum Type { GetDate, SetDate, GetTag, None, Error };
        public Type type = Type.None;
        public string data;
        public int index;
        public DateTime time;
    }
    public partial class ReaderForm : Form
    {
        ConcurrentQueue<Cmd> [] inQueue = new ConcurrentQueue<Cmd>[3];
        ConcurrentQueue<Cmd> outQueue = new ConcurrentQueue<Cmd>();

        private string countLRC(string s)
        {
            int sum = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                sum += s[i];
            }

            sum &= 0xff;

            return sum.ToString("X2");
        }
        private bool checkLRC(string s, string lrc)
        {
            return lrc == countLRC(s);
        }

        public void logging(string msg)
        {
            Trace.WriteLine(String.Format("{0} - {1}", DateTime.Now, msg));
        }

        private DateTime stringToDateTime(string s)
        {
            int year = 1900 + (s[0] - '0') * 10 + (s[1] - '0');
            int month = (s[2] - '0') * 10 + (s[3] - '0');
            int day = (s[4] - '0') * 10 + (s[5] - '0');
            // s[6~7] indicates the day of week e.g. Monday
            if (s.Length == 14) s = "xx" + s;
            int hour = (s[8] - '0') * 10 + (s[9] - '0');
            int min = (s[10] - '0') * 10 + (s[11] - '0');
            int sec = (s[12] - '0') * 10 + (s[13] - '0');
            int ms = int.Parse(s.Substring(14, 2), System.Globalization.NumberStyles.HexNumber);

            return new DateTime(year, month, day, hour, min, sec, ms * 10);
        }

        private Cmd stringToCmd(string msg)
        {
            logging("收到資料: " + msg);
            Cmd cmd = new Cmd();
            cmd.type = Cmd.Type.None;
            if(msg.Substring(0, 2) == "aa")
            {
                logging("判斷指令為aa開頭");
                string tag = msg.Substring(4, 12);
                if (tag.Substring(0, 3) != "058")
                    logging("Notice: tag prefix is not 058");
                cmd.type = Cmd.Type.GetTag;
                cmd.data = tag;
                cmd.time = stringToDateTime(msg.Substring(19, 14));
            }

            if(msg.Substring(0, 2) == "ab")
            {
                logging("判斷指令為ab開頭");
                string reader_id = msg.Substring(2, 2);
                int length = Int32.Parse(msg.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                logging("偵測長度為" + length);
                string instruction = msg.Substring(6, 2);
                logging("指令編號為" + instruction);
                string data = length == 0 ? "" : msg.Substring(8, length);
                //char lrc = msg[8 + length];

                if (instruction == "01")
                {
                    if(length == 0)
                        logging("收到資料為 SetDate ACK [Ignored]");
                    else
                    {
                        logging("嘗試轉換時間");
                        cmd.time = stringToDateTime(data);
                        logging("收到時間為" + cmd.time);
                        cmd.type = Cmd.Type.SetDate;
                    }
                }

                if(instruction == "02")
                {
                    logging("收到GetDate回應 嘗試轉換");
                    cmd.time = stringToDateTime(data);
                    logging("收到時間為" + cmd.time);
                    cmd.type = Cmd.Type.GetDate;
                }

                if (instruction[0] == 'f')
                    cmd.type = Cmd.Type.Error;
                if (instruction == "f0")
                    logging("Error: Bad Length (>10)");
                if (instruction == "f1")
                    logging("Error: Bad LRC");
                if (instruction == "f2")
                    logging("Error: Unknown Instruction");
                if (instruction == "f3")
                    logging("Error: Reserved");
                if (instruction == "f4")
                    logging("Error: Unsupported command");
                if (instruction == "f5")
                    logging("Error: Unsupported sub-command");
            }

            return cmd;
        }

        private string CmdToString(Cmd cmd)
        {
            string str = "ab";
            if (cmd.type == Cmd.Type.GetDate)
                str += "00002222\r\n";

            if(cmd.type == Cmd.Type.SetDate)
            {
                string data = "000701" + DateTime.Now.ToString("yyMMdd") + (int)DateTime.Now.DayOfWeek + DateTime.Now.ToString("HHmmss");
                data += countLRC(data) + "\r\n";
                logging("SetDate指令字串: " + data);
                str += data;
            }

            if(cmd.type == Cmd.Type.GetTag)
            {
                str += "00ff4bc2\r\n";
            }

            return str;
        }

        private string runTcpClient(int index, string ip)
        {
            TcpClient client = null;
            NetworkStream stream = null;
            StreamReader reader = null;
            StreamWriter writer = null;

            logging(ip + "連接中");
            try
            {    
                client = new TcpClient(ip, 10000);
                stream = client.GetStream();
                stream.ReadTimeout = 100;
                reader = new StreamReader(stream, Encoding.ASCII);
                writer = new StreamWriter(stream, Encoding.ASCII);
                writer.NewLine = "\r\n";
            }
            catch (Exception ex)
            {
                logging(ip + "網路連線失敗" + ex.Message);
                return ex.Message;
            }

            logging(ip + "連接成功");
            /* connection opened */
            while(client.Connected)
            {
                try
                {
                    string line = reader.ReadLine();
                    Cmd recv_cmd = stringToCmd(line);
                    recv_cmd.index = index;
                    outQueue.Enqueue(recv_cmd);
                }
                catch (IOException ex)
                {
                    Debug.WriteLine("Recv Ignore exception: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    if (ex is System.NullReferenceException)
                        return "對方斷線";
                    if (ex is System.Net.Sockets.SocketException)
                    {
                        SocketException sex = (SocketException)ex;
                        return sex.Message;
                    }
                    return ex.Message;
                }

                Cmd send_cmd = null;
                if (false == inQueue[index].TryDequeue(out send_cmd)) continue;
                
                try
                {
                    string send_str = CmdToString(send_cmd);
                    writer.WriteLine(send_str);
                    writer.Flush();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Send Ignore exception: " + ex.Message);
                }
            }

            logging(ip + "連線中斷");
            return "網路連線已斷開";
        }
    }
}
