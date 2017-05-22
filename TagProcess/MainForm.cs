using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using Excel = Microsoft.Office.Interop.Excel;


namespace TagProcess
{
    public partial class MainForm : Form
    {
        private Core core = null;
        private ParticipantsViewForm pv = null;

        public MainForm()
        {
            InitializeComponent();

            core = new Core(logging);

            string url = Properties.Settings.Default.ServerUrl;
            logging(0, core.setServerUrl(url));

            refreshCOMPort();
        }

        /// <summary>
        /// 顯示輸入伺服器網址視窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 伺服器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServerUrlInputForm input = new ServerUrlInputForm();
            if (input.ShowDialog() == DialogResult.OK)
            {
                logging(0, core.setServerUrl(input.GetResult()));
            }
        }

        /// <summary>
        /// 從伺服器下載並顯示選手資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void partcipants_view_button_Click(object sender, EventArgs e)
        {
            if(!core.checkServerStatus())
            {
                MessageBox.Show("請先設定伺服器網址");
                伺服器ToolStripMenuItem_Click(null, null);
                return;
            }

            // TODO: 考慮移除這個檢測
            if(!core.is_comport_opened())
            {
                MessageBox.Show("請先設定讀卡機COM Port");
                return;
            }

            logging(0, "下載選手資料中，請稍後");
            if(!core.loadParticipants())
            {
                MessageBox.Show("下載選手資料失敗，請重試");
                return;
            }
            logging(0, "下載選手資料完成");
            pv = new ParticipantsViewForm(this, core);
            this.Hide();
            pv.Show();
        }

        /// <summary>
        /// 從伺服器下載選手資料並產生PDF檔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void print_mail_button_Click(object sender, EventArgs e)
        {
            if (!core.checkServerStatus())
            {
                MessageBox.Show("請先設定伺服器網址");
                伺服器ToolStripMenuItem_Click(null, null);
                return;
            }

            logging(0, "下載選手資料中，請稍後");
            if (!core.loadParticipants())
            {
                MessageBox.Show("下載選手資料失敗，請重試");
                return;
            }
            logging(0, "下載選手資料完成");

            core.gen_mail_pdf();
        }

        /// <summary>
        /// 重新抓取目前的所有COMPort
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 重新整理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshCOMPort();
        }

        /// <summary>
        /// 連接到特定COMPort
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void COMPortConnect_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in COMToolStripMenuItem.DropDownItems)
            {
                t.Checked = false;
            }

            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if(core.connect_comport(item.Text))
            {
                item.Checked = true;
            }
        }

        private void pair_form_button_Click(object sender, EventArgs e)
        {
            if (!core.checkServerStatus())
            {
                MessageBox.Show("請先設定伺服器網址");
                伺服器ToolStripMenuItem_Click(null, null);
                return;
            }

            logging(0, "下載選手資料中，請稍後");
            if (!core.loadParticipants())
            {
                MessageBox.Show("下載選手資料失敗，請重試");
                return;
            }
            logging(0, "下載選手資料完成");

            TagPairingForm form = new TagPairingForm(core);
            form.ShowDialog();
        }

        private void log檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("log.txt");
        }

        private void import_button_Click(object sender, EventArgs e)
        {
            if (!core.checkServerStatus())
            {
                MessageBox.Show("請先設定伺服器網址");
                伺服器ToolStripMenuItem_Click(null, null);
                return;
            }

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select File";
            dialog.InitialDirectory = ".\\";
            dialog.Filter = "xls files (*.*)|*.xls";
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            string path = dialog.FileName;
            Debug.WriteLine(path);

            excelWorker.RunWorkerAsync(path);
        }

        private void excelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            excelWorker.ReportProgress(0, "開啟中");
            string path = (string)e.Argument;
            Excel.Application excel = new Excel.Application();
            Excel.Workbook book = null;
            excel.Visible = false;
            try
            {
                book = excel.Workbooks.Open(path);
                var sheets = book.Sheets;
                Excel.Worksheet sheet = sheets["報名資料-依團體順序"];
                Excel.Range range = sheet.UsedRange;
                var row = range.Rows.Count;
                var col = range.Columns.Count;
                Dictionary<int, string> db_map = new Dictionary<int, string>{
                    { 7, "race_id" },
                    { 8, "name" },
                    { 11, "group" },
                    { 10, "male" },
                    { 15, "birth" },
                    { 21, "address" },
                    { 18, "phone" }
                };

                List<Dictionary<string, string>> data = new List<System.Collections.Generic.Dictionary<string, string>>();
                HashSet<string> groups = new HashSet<string>();

                for (int i = 2; i <= row; ++i)
                {
                    Dictionary<string, string> tmp = new Dictionary<string, string>();
                    foreach (var item in db_map)
                    {
                        //Debug.WriteLine(i + " " + item.Key);
                        tmp.Add(item.Value, (string)(range.Cells[i, item.Key] as Excel.Range).Text.ToString());
                    }
                    groups.Add((string)(range.Cells[i, 11] as Excel.Range).Text.ToString());
                    data.Add(tmp);
                    excelWorker.ReportProgress(i/row, String.Format("{0}/{1}", i-1, row-1));
                }
                excelWorker.ReportProgress(100, "上傳中");
                string str = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                string str_group = Newtonsoft.Json.JsonConvert.SerializeObject(groups);
                if (true == core.importParticipant(str, str_group))
                    excelWorker.ReportProgress(100, "上傳成功");
                else
                    excelWorker.ReportProgress(100, "上傳失敗");
                /*
                foreach(Excel.Worksheet sheet in sheets)
                {
                    Excel.Range range = sheet.UsedRange;
                    Debug.WriteLine((string)sheet.Name);
                    var row = range.Rows.Count;
                    var col = range.Columns.Count;
                    for(int i = 1; i <= col; ++i)
                    {
                        Debug.Write((string)(range.Cells[1, i] as Excel.Range).Value2);
                    }
                }
                */

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                book.Close(false);
                excel.Quit();
            }
        }

        private void excelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void excelWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            output_StatusLabel.Text = e.UserState as string;
        }
    }
}
