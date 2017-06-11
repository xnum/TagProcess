using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagProcess
{
    public class TagUSBReader
    {
        private static readonly TagUSBReader _instance = new TagUSBReader();
        private TagUSBReader()
        {

        }

        public static TagUSBReader Instance { get { return _instance; } }

        private SerialPort comport = null;

        public string[] getPortNames()
        {
            return SerialPort.GetPortNames();
        }
        public bool connect(string port)
        {
            try
            {
                comport = new SerialPort(port, 9600, Parity.None, 8, StopBits.One);
                comport.Open();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool isConnected()
        {
            return comport != null && comport.IsOpen;
        }

        /// <summary>
        /// 取得感應到的tag，如果沒有感應到會回傳String.Empty，500ms Timeout
        /// </summary>
        /// <returns></returns>
        public string readTag()
        {
            comport.ReadTimeout = 500;
            string lastValidTag = String.Empty;
            while (true)
            {
                try
                {
                    comport.DiscardInBuffer();
                    comport.DiscardOutBuffer();
                    // look like this aa00058003235b7001000401010035365676
                    string data = comport.ReadLine();
                    if (data[0] == 'a' && data[1] == 'a')
                    {
                        string tag_id = data.Substring(4, 12);
                        lastValidTag = tag_id;
                        comport.ReadTimeout = 100;
                    }
                }
                catch (TimeoutException)
                {
                    // 確保緩衝區內已無任何資料
                    return lastValidTag;
                }
            }
        }
    }
}
