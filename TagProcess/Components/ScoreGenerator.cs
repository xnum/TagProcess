using System;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using System.Management;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using RawPrint;
using System.Drawing.Printing;
using System.Drawing;
using System.Collections.Concurrent;

namespace TagProcess.Components
{
    public class ScoreArguments
    {
        public string today;
        public string name;
        public string group;
        public string team_name;
        public string total_rank;
        public string total_gender_rank;
        public string team_rank;
        public DateTime tag_start_time;
        public DateTime tag_end_time;
        public DateTime batch_start_time;

        public string batch_run_time;
        public string tag_run_time;
        public string reg;
        public string type;

        public bool Check()
        {
            // 隨便選一個 只要回傳false就好
            if (name == "")
                return DialogResult.Ignore == MessageBox.Show("姓名為空");

            if (group == "")
                return DialogResult.Ignore == MessageBox.Show("組別為空");

            if (team_rank == "")
                return DialogResult.Ignore == MessageBox.Show("組別名次為空");

            if (tag_start_time.CompareTo(new DateTime(2017, 10, 28)) <= 0 || tag_start_time.CompareTo(DateTime.Now) >= 0)
                return DialogResult.Ignore == MessageBox.Show("晶片開始時間有誤" + tag_start_time);

            if (tag_end_time.CompareTo(new DateTime(2017, 10, 28)) <= 0 || tag_end_time.CompareTo(DateTime.Now) >= 0)
                return DialogResult.Ignore == MessageBox.Show("晶片結束時間有誤" + tag_end_time);

            if (batch_start_time.CompareTo(new DateTime(2017, 10, 28)) <= 0 || batch_start_time.CompareTo(DateTime.Now) >= 0)
                return DialogResult.Ignore == MessageBox.Show("大會開始時間有誤" + batch_start_time);

            if (tag_end_time.CompareTo(tag_start_time) <= 0)
                return DialogResult.Ignore == MessageBox.Show("晶片結束時間" + tag_end_time + "小於晶片開始時間" + tag_start_time);

            if (tag_end_time.CompareTo(batch_start_time) <= 0)
                return DialogResult.Ignore == MessageBox.Show("晶片結束時間" + tag_end_time + "小於大會開始時間" + batch_start_time);

            return true;
        }

        public ScoreArguments()
        {

        }

        /// <summary>
        /// 傳入參數前應該檢查是否資料正確
        /// </summary>
        /// <param name="res"></param>
        public ScoreArguments(TimeKeeper.RecordResult res)
        {
            today = DateTime.Now.ToShortDateString();
            name = res.name;
            group = res.chip_race_group_name;
            team_name = res.team_name;
            reg = res.reg;
            type = res.type;
            total_rank = res.total_rank.ToString();
            total_gender_rank = res.total_gender_rank.ToString();
            team_rank = res.group_rank.ToString();
            batch_run_time = TimeSpan.FromSeconds(res.activity_time).ToString(@"hh' 小時 'mm' 分 'ss' 秒'");
            tag_run_time = TimeSpan.FromSeconds(res.personal_time).ToString(@"hh' 小時 'mm' 分 'ss' 秒'");
            batch_start_time = res.chip_race_group_start_time;
            tag_end_time = res.chip_user_start_time;
            tag_start_time = res.chip_user_end_time;

            /*
            batch_start_time = res.group.batch_start_time;

            foreach (var r in res.recs)
            {
                switch (r.station_id)
                {
                    case "1":
                        tag_start_time = r.time;
                        break;
                    case "5":
                        tag_end_time = r.time;
                        break;
                }
            }

            CountRunTime();
            */
        }

        public void CountRunTime()
        {
            batch_run_time = tag_end_time.Subtract(batch_start_time).ToString(@"hh' 小時 'mm' 分 'ss' 秒'");
            tag_run_time = tag_end_time.Subtract(tag_start_time).ToString(@"hh' 小時 'mm' 分 'ss' 秒'");
        }
    }
    public class ScoreGenerator
    {
        public static string printer;
        public static BlockingCollection<ScoreArguments> queue = new BlockingCollection<ScoreArguments>();
        private static System.Drawing.Font font;
        public static ScoreArguments args = new ScoreArguments();

        public static void printPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(ScoreGenerator.args.name, font, Brushes.Black, 400, 150, new StringFormat());
            //e.Graphics.DrawString(ScoreGenerator.args.today, font, Brushes.Black, 400, 250, new StringFormat());
            e.Graphics.DrawString(ScoreGenerator.args.group, font, Brushes.Black, 400, 350, new StringFormat());
            e.Graphics.DrawString(ScoreGenerator.args.team_name, font, Brushes.Black, 400, 450, new StringFormat());
            e.Graphics.DrawString(ScoreGenerator.args.batch_run_time, font, Brushes.Black, 400, 550, new StringFormat());
            e.Graphics.DrawString(ScoreGenerator.args.tag_run_time, font, Brushes.Black, 400, 650, new StringFormat());
            e.Graphics.DrawString(ScoreGenerator.args.total_rank, font, Brushes.Black, 400, 750, new StringFormat());
            e.Graphics.DrawString(ScoreGenerator.args.team_rank, font, Brushes.Black, 400, 850, new StringFormat());
        }

        public static void Worker()
        {
            font = new System.Drawing.Font("KAIU", 16);
            while (!queue.IsAddingCompleted)
            {
                try
                {
                    ScoreArguments a = queue.Take();
                    args = a;
                    PrintDocument pd = new PrintDocument();
                    PrintController pc = new System.Drawing.Printing.StandardPrintController();
                    if (printer != "") pd.PrinterSettings.PrinterName = printer;
                    pd.PrintPage += printPage;
                    pd.PrintController = pc;
                    pd.Print();
                }
                catch
                {
                    return;
                }
            }
        }

        public static void exportScoreToPDF(ScoreArguments args, string printer)
        {
            ScoreGenerator.printer = printer;
            queue.Add(args);

            //this.args = args;


        }

        public static void exportScoreToPDFB(ScoreArguments args, string printer)
        {
            var doc = new Document(PageSize.A4, 3, 3, 3, 3);
            var writer = PdfWriter.GetInstance(doc, new FileStream(args.name + "score.pdf", FileMode.Create));
            string chFontPath = "c:\\windows\\fonts\\KAIU.TTF";
            BaseFont chBaseFont = BaseFont.CreateFont(chFontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font textFont = new iTextSharp.text.Font(chBaseFont, 16);

            doc.Open();

            try
            {
                iTextSharp.text.Image bg = iTextSharp.text.Image.GetInstance("a.jpg");
                bg.Alignment = iTextSharp.text.Image.UNDERLYING;
                bg.ScaleToFit(doc.PageSize.Width - 6, doc.PageSize.Height - 6);
                bg.SetAbsolutePosition(3, 3);
                doc.Add(bg);
            }
            catch { }


            ColumnText ct = new ColumnText(writer.DirectContent);
            Phrase myText = new Phrase(args.name, textFont);
            ct.SetSimpleColumn(myText, 300, 300, 780, 685, 15, Element.ALIGN_LEFT);
            ct.Go();

            myText = new Phrase(args.today, textFont);
            ct.SetSimpleColumn(myText, 300, 300, 780, 635, 15, Element.ALIGN_LEFT);
            ct.Go();

            myText = new Phrase(args.group, textFont);
            ct.SetSimpleColumn(myText, 300, 300, 780, 585, 15, Element.ALIGN_LEFT);
            ct.Go();

            myText = new Phrase(args.team_name, textFont);
            ct.SetSimpleColumn(myText, 300, 300, 780, 535, 15, Element.ALIGN_LEFT);
            ct.Go();

            myText = new Phrase(args.batch_run_time, textFont);
            ct.SetSimpleColumn(myText, 300, 300, 780, 475, 15, Element.ALIGN_LEFT);
            ct.Go();

            myText = new Phrase(args.tag_run_time, textFont);
            ct.SetSimpleColumn(myText, 300, 300, 780, 425, 15, Element.ALIGN_LEFT);
            ct.Go();

            myText = new Phrase(args.total_rank, textFont);
            ct.SetSimpleColumn(myText, 300, 300, 780, 375, 15, Element.ALIGN_LEFT);
            ct.Go();

            if (args.team_rank != "0")
            {
                myText = new Phrase(args.team_rank, textFont);
                ct.SetSimpleColumn(myText, 300, 300, 780, 325, 15, Element.ALIGN_LEFT);
                ct.Go();
            }

            doc.Close();

            //Process.Start("score.pdf");
            //Thread t = new Thread(Print);
            //t.IsBackground = true;
            //t.Start(args.name + "score.pdf");
            //Print(args.name + "score.pdf");
            string filename = args.name + "score.pdf";
            string pwd = Directory.GetCurrentDirectory();
            IPrinter p = new Printer();
            GSPrint(printer, pwd + "\\" + filename);
            //p.PrintRawFile(printer, pwd + "\\" + filename, filename);
            //PDFPrint.SendFileToPrinter();
        }

        public static void GSPrint(string printer, string filename)
        {
            const string gsPrintExecutable = @"D:\Ghostgum\gsview\gsprint.exe";
            const string gsExecutable = @"C:\Program Files\gs\gs9.22\bin\gswin64c.exe";

            string processArgs = string.Format("-ghostscript \"{0}\" -copies=1 -all -printer \"{1}\" \"{2}\"", gsExecutable, printer, filename);

            var gsProcessInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = gsPrintExecutable,
                Arguments = processArgs
            };

            using (var gsProcess = Process.Start(gsProcessInfo))
            {
                gsProcess.WaitForExit();
            }
        }

        public static void Print(object param)
        {
            string filePath = (string)param;
            PDFPrint.SendFileToPrinter(filePath);
            return;

            //var Status = PrintJobStatus.Printing;
            var Message = string.Empty;
            try
            {
                //logger.Debug($"Printing... {filePath}");
                ProcessStartInfo info = new ProcessStartInfo();
                info.Verb = "print";
                info.FileName = filePath;
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;

                Process p = new Process();
                p.StartInfo = info;
                p.Start();

                p.WaitForInputIdle();
                //以下邏輯克服無法得知Acrobat Reader或Foxit Reader是否列印完成的問題
                //最多等待180秒（假設所有檔案可在3分鐘內印完）
                var timeOut = DateTime.Now.AddSeconds(180);
                bool printing = false; //是否開始列印
                bool done = false; //是否列印完成
                                   //取純檔名部分，跟PrintQueue進行比對
                string pureFileName = Path.GetFileName(filePath);
                //限定最大等待時間
                while (DateTime.Now.CompareTo(timeOut) < 0)
                {
                    if (!printing)
                    {
                        //未開始列印前發現檔名相同的列印工作
                        if (CheckPrintQueue(pureFileName))
                        {
                            printing = true;
                            Console.WriteLine($"[{pureFileName}]列印中...");
                        }
                    }
                    else
                    {
                        //已開始列印後，同檔名列印工作消失表示列印完成
                        if (!CheckPrintQueue(pureFileName))
                        {
                            done = true;
                            Console.WriteLine($"[{pureFileName}]列印完成");
                            break;
                        }
                    }
                    System.Threading.Thread.Sleep(100);
                }
                try
                {
                    //若程序尚未關閉，強制關閉之
                    if (false == p.CloseMainWindow())
                        p.Kill();
                }
                catch
                {
                }
                if (!done)
                {
                    Console.WriteLine($"無法確認報表[{pureFileName}]列印狀態！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {DateTime.Now:HH:mm:ss} {ex.Message}");
            }
        }

        //需查詢 WMI 記得加入參照及 using System.Management; 
        private static bool CheckPrintQueue(string file)
        {
            //尋找PrintQueue有沒有檔案相同的列印工作
            string searchQuery =
                "SELECT * FROM Win32_PrintJob";
            var printJobs =
                     new ManagementObjectSearcher(searchQuery).Get();
            foreach (ManagementObject job in printJobs)
            {
                if ((string)job.Properties["Document"].Value == file)
                    return true;
            }
            return false;
            //return printJobs.Any(o => (string)o.Properties["Document"].Value == file);
        }
    }
}
