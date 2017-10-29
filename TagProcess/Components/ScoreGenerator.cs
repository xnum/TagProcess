using System;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using System.Management;
using System.Collections.Generic;
using System.Threading;

namespace TagProcess.Components
{
    public class ScoreGenerator
    {
        public class ScoreArguments
        {
            public string today;
            public string name;
            public string group;
            public string team_name;
            public string overall_rank;
            public string team_tank;
            public DateTime tag_start_time;
            public DateTime tag_end_time;
            public DateTime batch_start_time;

            public string batch_run_time;
            public string tag_run_time;

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
                name = res.p["name"];
                group = res.group.name;
                team_name = res.p["team_name"];
                overall_rank = res.overall.ToString();
                team_tank = res.team.ToString();
                tag_end_time = new DateTime(1999, 12, 31);
                tag_start_time = new DateTime(1999, 12, 31);
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
            }

            public void CountRunTime()
            {
                batch_run_time = tag_end_time.Subtract(batch_start_time).ToString(@"hh' 小時 'mm' 分 'ss' 秒'");
                tag_run_time = tag_end_time.Subtract(tag_start_time).ToString(@"hh' 小時 'mm' 分 'ss' 秒'");
            }
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

            myText = new Phrase(args.overall_rank, textFont);
            ct.SetSimpleColumn(myText, 300, 300, 780, 375, 15, Element.ALIGN_LEFT);
            ct.Go();

            if (args.team_tank != "0")
            { 
                myText = new Phrase(args.team_tank, textFont);
                ct.SetSimpleColumn(myText, 300, 300, 780, 325, 15, Element.ALIGN_LEFT);
                ct.Go();
            }

            doc.Close();

            //Process.Start("score.pdf");
            Thread t = new Thread(Print);
            t.IsBackground = true;
            t.Start(args.name + "score.pdf");
            //Print(args.name + "score.pdf");
        }

        public static void Print(object param)
        {
            string filePath = (string)param;
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
