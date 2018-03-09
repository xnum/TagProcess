using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagProcess
{
    class FileLogger : IDisposable
    {
        private static readonly FileLogger _instance = new FileLogger();

        private FileStream pacFile;
        private StreamWriter pacWriter;

        private FileLogger()
        {
            StreamWriter writer;
            writer = new StreamWriter("log.txt", true);
            TextWriterTraceListener mylog = new TextWriterTraceListener(writer);
            Debug.Listeners.Add(mylog);
            Debug.AutoFlush = true;

            Trace.WriteLine("---- Program started at " + DateTime.Now.ToString() + "----");

            pacFile = new FileStream("packet.txt", FileMode.Append, FileAccess.Write, FileShare.Read, bufferSize: 4096);
            pacWriter = new StreamWriter(pacFile, Encoding.UTF8);
            pacWriter.AutoFlush = true;

            pacWriter.WriteLine("---- Program started at " + DateTime.Now.ToString() + "----");
        }

        public static FileLogger Instance { get { return _instance; } }

        public void log(string msg)
        {
            Trace.WriteLine(String.Format("{0} - {1}", DateTime.Now, msg));
        }

        public void logPacket(string msg)
        {
            pacWriter.WriteLine(msg);
        }

        #region IDisposable Support
        private bool disposedValue = false; // 偵測多餘的呼叫

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    
                    pacWriter.Dispose();
                    pacFile.Dispose();
                    // TODO: 處置 Managed 狀態 (Managed 物件)。
                }

                // TODO: 釋放 Unmanaged 資源 (Unmanaged 物件) 並覆寫下方的完成項。
                // TODO: 將大型欄位設為 null。
                pacWriter = null;
                pacFile = null;

                disposedValue = true;
            }
        }

        // TODO: 僅當上方的 Dispose(bool disposing) 具有會釋放 Unmanaged 資源的程式碼時，才覆寫完成項。
        // ~FileLogger() {
        //   // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 加入這個程式碼的目的在正確實作可處置的模式。
        public void Dispose()
        {
            // 請勿變更這個程式碼。請將清除程式碼放入上方的 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果上方的完成項已被覆寫，即取消下行的註解狀態。
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
