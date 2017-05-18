using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagProcess
{
    public partial class Core
    {
        private SerialPort comport = null;
        public bool connect_COMPort(string port)
        {
            try
            {
                comport = new SerialPort(port, 9600, Parity.None, 8, StopBits.One);
                comport.Open();
            }
            catch
            {
                msgCallback(0, port + "連線失敗");
                return false;
            }

            msgCallback(0, port + "連線成功");
            return true;
        }

        public string comport_get_tag()
        {
            comport.ReadTimeout = 500;
            string lastTag = String.Empty;
            while (true) {
                try
                {
                    // look like this aa00058003235b7001000401010035365676
                    string data = comport.ReadLine();
                    if (data[0] == 'a' && data[1] == 'a')
                    {
                        string tag_id = data.Substring(4, 12);
                        Debug.WriteLine(tag_id);
                        lastTag = tag_id;
                    }
                }
                catch
                {
                     break;
                }
            }

            return lastTag;
        }
    }
}
