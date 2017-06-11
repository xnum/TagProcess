using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagProcess
{
    class FileLogger
    {
        private static readonly FileLogger _instance = new FileLogger();

        private FileStream pacFile;
        private StreamWriter pacWriter;

        private FileLogger()
        {
            TextWriterTraceListener mylog = new TextWriterTraceListener(System.IO.File.CreateText("log.txt"));
            Debug.Listeners.Add(mylog);
            Debug.AutoFlush = true;

            pacFile = new FileStream("packet.txt", FileMode.Append, FileAccess.Write, FileShare.Read, bufferSize: 4096);
            pacWriter = new StreamWriter(pacFile, Encoding.ASCII);
        }

        public static FileLogger Instance { get { return _instance; } }

        public void log(string msg)
        {
            Trace.WriteLine(String.Format("{0} - {1}", DateTime.Now, msg));
        }

        public void logPacket(string msg)
        {
            pacWriter.WriteLineAsync(msg);
        }
    }
}
