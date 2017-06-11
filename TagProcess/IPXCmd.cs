using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagProcess
{
    public class IPXCmd
    {
        public enum Type { GetDate, SetDate, GetTag, None, Error };
        public Type type = Type.None;
        public string data;
        public DateTime time;
        public IPXCmd() { }
        public IPXCmd(Type t) { type = t; }
        public IPXCmd(string msg)
        {
            logging("Construct: " + msg);
            type = Type.None;
            if (msg.Substring(0, 2) == "aa")
            { // aa 00 058003 22d0ee 0100 170605 203041 5f 0b
                string tag = msg.Substring(4, 12);
                if (tag.Substring(0, 3) != "058")
                    logging("Notice: tag prefix is not 058");
                type = Type.GetTag;
                data = tag;
                time = stringToDateTime(msg.Substring(20, 14));
            }

            if (msg.Substring(0, 2) == "ab")
            {
                string reader_id = msg.Substring(2, 2);
                int length = Int32.Parse(msg.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                string instruction = msg.Substring(6, 2);
                logging("指令編號為" + instruction);
                string data = length == 0 ? "" : msg.Substring(8, length);

                if (instruction == "01")
                {
                    if (length == 0)
                        logging("收到資料為 SetDate ACK [Ignored]");
                    else
                    {
                        logging("嘗試轉換時間");
                        time = stringToDateTime(data);
                        logging("收到時間為" + time);
                        type = Type.SetDate;
                    }
                }

                if (instruction == "02")
                {
                    logging("收到GetDate回應 嘗試轉換");
                    time = stringToDateTime(data);
                    logging("收到時間為" + time);
                    type = Type.GetDate;
                }

                if (instruction[0] == 'f')
                    type = Type.Error;
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
        }

        public override string ToString()
        {
            string str = "ab";
            if (type == Type.GetDate)
                str += "00002222\r\n";

            if (type == Type.SetDate)
            {
                string data = "000701" + DateTime.Now.ToString("yyMMdd") + "0" + (int)DateTime.Now.DayOfWeek + DateTime.Now.ToString("HHmmss");
                data += countLRC(data) + "\r\n";
                logging("SetDate指令字串: " + data);
                str += data;
            }

            return str;
        }

        private string countLRC(string s)
        {
            int sum = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                sum += s[i];
            }

            sum &= 0xff;

            return sum.ToString("x2");
        }
        private bool checkLRC(string s, string lrc)
        {
            return lrc == countLRC(s);
        }

        private DateTime stringToDateTime(string s)
        {
            int year = 2000 + (s[0] - '0') * 10 + (s[1] - '0');
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

        private static void logging(string msg)
        {
            FileLogger.Instance.log(msg);
        }
    }
}
