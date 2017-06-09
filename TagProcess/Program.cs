using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TagProcess
{
    
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RaceServer.Instance.Log += FileLogger.Instance.log;
            ParticipantsRepository.Instance.Log += FileLogger.Instance.log;
            Application.Run(new MainForm());
        }
    }
}
