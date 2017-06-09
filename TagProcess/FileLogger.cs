using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagProcess
{
    class FileLogger
    {
        private static readonly FileLogger _instance = new FileLogger();
        private FileLogger()
        {
            TextWriterTraceListener mylog = new TextWriterTraceListener(System.IO.File.CreateText("log.txt"));
            Debug.Listeners.Add(mylog);
            Debug.AutoFlush = true;
        }

        public static FileLogger Instance { get { return _instance; } }

        public void log(string msg)
        {
            Trace.WriteLine(String.Format("{0} - {1}", DateTime.Now, msg));
        }
    }
}
