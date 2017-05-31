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
        ConcurrentQueue<Cmd> inQueue = new ConcurrentQueue<Cmd>();
        ConcurrentQueue<Cmd> outQueue = new ConcurrentQueue<Cmd>();

        private bool checkLRC(string s, string lrc)
        {
            int sum = 0;
            for(int i = 0; i < s.Length; ++i)
            {
                sum += s[i];
            }

            sum &= 0xff;

            return lrc == sum.ToString("X2");
        }

        private DateTime stringToDateTime(string s)
        {
            int year = 1900 + (s[0] - '0') * 10 + (s[1] - '0');
            int month = (s[2] - '0') * 10 + (s[3] - '0');
            int day = (s[4] - '0') * 10 + (s[5] - '0');
            // s[6~7] indicates the day of week e.g. Monday
            int hour = (s[8] - '0') * 10 + (s[9] - '0');
            int min = (s[10] - '0') * 10 + (s[11] - '0');
            int sec = (s[12] - '0') * 10 + (s[13] - '0');
            int ms = int.Parse(s.Substring(14, 2), System.Globalization.NumberStyles.HexNumber);

            return new DateTime(year, month, day, hour, min, sec, ms * 10);
        }

        private Cmd stringToCmd(string msg)
        {
            Cmd cmd = new Cmd();
            cmd.type = Cmd.Type.None;
            Debug.WriteLine("processing: " + msg);
            if(msg.Substring(0, 2) == "aa")
            {
                string tag = msg.Substring(2, 12);
                if (tag.Substring(0, 3) != "058")
                    Debug.WriteLine("Notice: prefix is not 058");
                cmd.type = Cmd.Type.GetTag;
                cmd.data = tag;
                cmd.time = DateTime.Now;
            }

            if(msg.Substring(0, 2) == "ab")
            {
                string reader_id = msg.Substring(2, 2);
                int length = Int32.Parse(msg.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                string instruction = msg.Substring(6, 2);
                string data = length == 0 ? "" : msg.Substring(8, length);
                char lrc = msg[8 + length];

                if (instruction == "01")
                {
                    if(length == 0)
                        Debug.WriteLine("SetDate ACK ... [Ignored]");
                    else
                    {
                        cmd.time = stringToDateTime(data);
                        cmd.type = Cmd.Type.SetDate;
                    }
                }

                if(instruction == "02")
                {
                    cmd.time = stringToDateTime(data);
                    cmd.type = Cmd.Type.GetDate;
                }

                if (instruction[0] == 'f')
                    cmd.type = Cmd.Type.Error;
                if (instruction == "f0")
                    Debug.WriteLine("Error: Bad Length (>10)");
                if (instruction == "f1")
                    Debug.WriteLine("Error: Bad LRC");
                if (instruction == "f2")
                    Debug.WriteLine("Error: Unknown Instruction");
                if (instruction == "f3")
                    Debug.WriteLine("Error: Reserved");
                if (instruction == "f4")
                    Debug.WriteLine("Error: Unsupported command");
                if (instruction == "f5")
                    Debug.WriteLine("Error: Unsupported sub-command");
            }

            return cmd;
        }

        private string CmdToString(Cmd cmd)
        {
            return "";
        }

        private string runTcpClient(int index, string ip)
        {
            TcpClient client = null;
            NetworkStream stream = null;
            StreamReader reader = null;
            StreamWriter writer = null;
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
                return "網路連線失敗" + ex.Message;
            }

            /* connection opened */
            while(client.Connected)
            {
                try
                {
                    string line = reader.ReadLine();
                    Cmd recv_cmd = stringToCmd(line);
                    outQueue.Enqueue(recv_cmd);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Recv Ignore exception: " + ex.Message);
                }

                Cmd send_cmd = null;
                if (false == inQueue.TryDequeue(out send_cmd)) continue;

                try
                {
                    string send_str = CmdToString(send_cmd);
                    writer.WriteLine(send_str);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Send Ignore exception: " + ex.Message);
                }
            }

            return "網路連線已斷開";
        }
    }
}
