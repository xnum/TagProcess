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
        public string race_id;
        public string group;
        public string team_name;
        public int total_rank;
        public string total_gender_rank;
        public int team_rank;
        public DateTime tag_start_time;
        public DateTime tag_end_time;
        public DateTime batch_start_time;

        public string batch_run_time;
        public string tag_run_time;
        public string reg;
        public string type;

        public int group_count;
        public int class_count;

        public bool Check()
        {
            // 隨便選一個 只要回傳false就好
            if (name == "")
                return DialogResult.Ignore == MessageBox.Show("姓名為空");

            if(total_rank <= 0)
                return DialogResult.Ignore == MessageBox.Show("總名次為空");

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
            race_id = res.race_id;
            group = res.chip_race_group_name;
            team_name = res.team_name;
            reg = res.reg;
            type = res.type;
            total_rank = res.total_rank;
            total_gender_rank = res.total_gender_rank.ToString();
            team_rank = res.group_rank;
            var br_time = TimeSpan.FromSeconds(res.activity_time);
            batch_run_time = br_time.ToString(br_time.TotalSeconds >= 3600 ? @"hh' 小時 'mm' 分 'ss' 秒'" : @"mm' 分 'ss' 秒'");
            var tr_time = TimeSpan.FromSeconds(res.personal_time);
            tag_run_time = tr_time.ToString(tr_time.TotalSeconds >= 3600 ? @"hh' 小時 'mm' 分 'ss' 秒'" : @"mm' 分 'ss' 秒'");
            batch_start_time = res.chip_race_group_start_time;
            tag_end_time = res.chip_user_start_time;
            tag_start_time = res.chip_user_end_time;
            group_count = ActivityCountHelper.getGroupCount(res.group_id);
            class_count = ActivityCountHelper.getClassCount(res.group_id);
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
            e.Graphics.DrawString("選手姓名  :   " + args.name, font, Brushes.Black, 200, 350, new StringFormat());
            e.Graphics.DrawString("選手編號  :   " + args.race_id, font, Brushes.Black, 200, 430, new StringFormat());
            e.Graphics.DrawString("團體名稱  :   " + args.team_name, font, Brushes.Black, 200, 510, new StringFormat());
            e.Graphics.DrawString("參賽項目  :   " + args.reg, font, Brushes.Black, 200, 590, new StringFormat());
            e.Graphics.DrawString("參賽組別  :   " + args.type, font, Brushes.Black, 200, 670, new StringFormat());
            e.Graphics.DrawString("大會時間  :   " + args.batch_run_time, font, Brushes.Black, 200, 750, new StringFormat());
            e.Graphics.DrawString("晶片時間  :   " + args.tag_run_time, font, Brushes.Black, 200, 830, new StringFormat());
            e.Graphics.DrawString("大會名次  :   " + args.total_rank + " / " + args.class_count, font, Brushes.Black, 200, 910, new StringFormat());
            if (args.team_rank > 0)
            {
                e.Graphics.DrawString("分組名次  :   " + args.team_rank + " / " + args.group_count, font, Brushes.Black, 200, 990, new StringFormat());
            }
            else
            {
                e.Graphics.DrawString("分組名次  :   N / A", font, Brushes.Black, 200, 990, new StringFormat());
            }
        }

        public static void Worker()
        {
            font = new System.Drawing.Font("KAIU", 22, FontStyle.Bold);
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

        public static void SendToPrinter(ScoreArguments args, string printer)
        {
            ScoreGenerator.printer = printer;
            queue.Add(args);
        }
    }
}
