using System;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using System.Management;
using System.Collections.Generic;

namespace TagProcess.Components
{
    public class ScoreGenerator
    {
        public class ScoreArguments
        {
            public string date;
            public string name;
            public string group;
            public string subject;
            public string total_rank;
            public string subject_rank;
            public string batch_run_time;
            public string tag_run_time;
        }

        public static void exportScoreToPDF(ScoreArguments args)
        {
            var doc = new Document(PageSize.A4, 3, 3, 3, 3);
            var writer = PdfWriter.GetInstance(doc, new FileStream(args.name + "score.pdf", FileMode.Create));
            string chFontPath = "c:\\windows\\fonts\\KAIU.TTF";
            BaseFont chBaseFont = BaseFont.CreateFont(chFontPath, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font textFont = new Font(chBaseFont, 16);

            doc.Open();

            try
            {
                Image bg = Image.GetInstance("a.jpg");
                bg.Alignment = Image.UNDERLYING;
                bg.ScaleToFit(doc.PageSize.Width - 6, doc.PageSize.Height - 6);
                bg.SetAbsolutePosition(3, 3);
                doc.Add(bg);
            }
            catch { }


            ColumnText ct = new ColumnText(writer.DirectContent);
            Phrase myText = new Phrase(args.name, textFont);
            ct.SetSimpleColumn(myText, 300, 300, 780, 685, 15, Element.ALIGN_LEFT);
            ct.Go();

            myText = new Phrase(args.date, textFont);
            ct.SetSimpleColumn(myText, 300, 300, 780, 635, 15, Element.ALIGN_LEFT);
            ct.Go();

            myText = new Phrase(args.group, textFont);
            ct.SetSimpleColumn(myText, 300, 300, 780, 585, 15, Element.ALIGN_LEFT);
            ct.Go();

            myText = new Phrase(args.subject, textFont);
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

            if (args.subject_rank != "0")
            { 
                myText = new Phrase(args.subject_rank, textFont);
                ct.SetSimpleColumn(myText, 300, 300, 780, 325, 15, Element.ALIGN_LEFT);
                ct.Go();
            }

            doc.Close();

            //Process.Start("score.pdf");
            Print(args.name + "score.pdf");
        }

        public static void Print(string filePath)
        {
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
            foreach(ManagementObject job in printJobs)
            {
                if ((string)job.Properties["Document"].Value == file)
                    return true;
            }
            return false;
            //return printJobs.Any(o => (string)o.Properties["Document"].Value == file);
        }
    }
}
