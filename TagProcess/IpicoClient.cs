using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TagProcess
{
    class IpicoClient
    {
        public string ip = "";
        public int port = 10000;

        private ConcurrentQueue<IPXCmd> sendQ = new ConcurrentQueue<IPXCmd>();
        private ConcurrentQueue<IPXCmd> recvQ = new ConcurrentQueue<IPXCmd>();

        TcpClient client = null;
        NetworkStream stream = null;
        StreamReader reader = null;
        StreamWriter writer = null;

        public delegate void LogHandler(string msg);
        public event LogHandler Log;

        protected void OnLog(string msg)
        {
            Log?.Invoke(msg);
        }

        public IpicoClient(string ip)
        {
            this.ip = ip;
        }

        public bool connect()
        {
            OnLog(ip + "連接中");
            try
            {
                client = new TcpClient(ip, port);
                stream = client.GetStream();
                stream.ReadTimeout = 200;
                reader = new StreamReader(stream, Encoding.ASCII);
                writer = new StreamWriter(stream, Encoding.ASCII);
                writer.NewLine = "\r\n";
            }
            catch (Exception ex)
            {
                OnLog(ip + "網路連線失敗" + ex.Message);
                return false;
            }

            OnLog(ip + "連接成功");
            return true;
        }

        public bool run()
        { 
            IPXCmd cmd = new IPXCmd(IPXCmd.Type.SetDate);
            sendQ.Enqueue(cmd);
            /* connection opened */
            while (client.Connected)
            {
                IPXCmd sendCmd = null;
                if (true == sendQ.TryDequeue(out sendCmd)) {
                    try
                    {
                        string send_str = sendCmd.ToString();
                        writer.WriteLine(send_str);
                        writer.Flush();
                    }
                    catch (Exception ex)
                    {
                        OnLog("Send Ignore exception: " + ex.Message);
                    }
                }

                try
                {
                    string line = reader.ReadLine();
                    FileLogger.Instance.logPacket(line);
                    IPXCmd recvCmd = new IPXCmd(line);
                    recvQ.Enqueue(recvCmd);
                }
                catch (IOException)
                { // TODO ignore timedout 
                    //Debug.WriteLine("Recv Ignore exception: " + ex.Message);
                }
                catch (Exception ex)
                {
                    OnLog(ex.Message);
                    if (ex is SocketException)
                    {
                        SocketException sex = (SocketException)ex;
                        OnLog(sex.Message);
                    }
                    return false;
                }
            }

            OnLog(ip + "連線中斷");
            return true;
        }

        public bool isConnected()
        {
            return client != null && client.Connected;
        }

        public bool TryGet(out IPXCmd cmd)
        {
            return recvQ.TryDequeue(out cmd);
        }

        public void Put(IPXCmd cmd)
        {
            sendQ.Enqueue(cmd);
        }
    }
}
