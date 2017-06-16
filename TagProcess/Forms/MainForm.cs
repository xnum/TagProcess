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
using System.Runtime.InteropServices;
using TagProcess.Forms;

namespace TagProcess
{
    public partial class MainForm : Form
    {
        private RaceServer server = null;
        private TagUSBReader usbReader = null;
        private ParticipantsRepository repo = null;
        private ParticipantsViewForm pv = null;

        public MainForm()
        {
            InitializeComponent();
            server = RaceServer.Instance;
            repo = ParticipantsRepository.Instance;
            usbReader = TagUSBReader.Instance;
            server.Log += printToStatusLabel;
            string url = Properties.Settings.Default.ServerUrl;
            server.setServerUrl(url);
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
                server.setServerUrl(input.GetResult());
            }
        }

        /// <summary>
        /// 從伺服器下載並顯示選手資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void partcipants_view_button_Click(object sender, EventArgs e)
        {
            if(!server.isConnected())
            {
                MessageBox.Show("請先設定伺服器網址");
                伺服器ToolStripMenuItem_Click(null, null);
                return;
            }

            if(!usbReader.isConnected())
            {
                MessageBox.Show("請先設定讀卡機COM Port");
                return;
            }

            printToStatusLabel("下載選手資料中，請稍後");
            if(!repo.fetchParticipants())
            {
                MessageBox.Show("下載選手資料失敗，請重試");
                return;
            }
            printToStatusLabel("下載選手資料完成");
            pv = new ParticipantsViewForm();
            Hide();
            pv.ShowDialog();
            pv.Dispose();
            Show();
        }

        /// <summary>
        /// 從伺服器下載選手資料並產生PDF檔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void print_mail_button_Click(object sender, EventArgs e)
        {
            if (!server.isConnected())
            {
                MessageBox.Show("請先設定伺服器網址");
                伺服器ToolStripMenuItem_Click(null, null);
                return;
            }

            printToStatusLabel("下載選手資料中，請稍後");
            if (!repo.fetchParticipants())
            {
                MessageBox.Show("下載選手資料失敗，請重試");
                return;
            }
            printToStatusLabel("下載選手資料完成");
            MailLabelGenerator.exportLabelToPDF(repo.participants);
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
            if(usbReader.connect(item.Text))
            {
                item.Checked = true;
            }
        }

        private void pair_form_button_Click(object sender, EventArgs e)
        {
            if (!server.isConnected())
            {
                MessageBox.Show("請先設定伺服器網址");
                伺服器ToolStripMenuItem_Click(null, null);
                return;
            }

            printToStatusLabel("下載選手資料中，請稍後");
            if (!repo.fetchParticipants())
            {
                MessageBox.Show("下載選手資料失敗，請重試");
                return;
            }
            printToStatusLabel("下載選手資料完成");

            TagPairingForm form = new TagPairingForm();
            form.ShowDialog();
            form.Dispose();
        }

        private void log檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("log.txt");
        }

        private void import_button_Click(object sender, EventArgs e)
        {
            if (!server.isConnected())
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
            excelWorker.RunWorkerAsync(dialog.FileName);
        }

        private void excelWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            excelWorker.ReportProgress(0, "開啟中");
            string path = (string)e.Argument;
            Excel.Application excel = new Excel.Application();
            excel.Visible = false;

            Excel.Workbook book = null;
            Excel.Sheets sheets = null;
            Excel.Worksheet sheet = null;

            try
            {
                book = excel.Workbooks.Open(path);
                sheets = book.Sheets;
                sheet = sheets["報名資料-依團體順序"];
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
                if (true == repo.storeParticipants(str, str_group))
                    excelWorker.ReportProgress(100, "上傳成功");
                else
                    excelWorker.ReportProgress(100, "上傳失敗");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                book.Close(0);
                excel.Quit();
                Marshal.ReleaseComObject(sheet);
                Marshal.ReleaseComObject(sheets);
                Marshal.ReleaseComObject(book);
                Marshal.ReleaseComObject(excel);
            }
        }

        private void excelWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void excelWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            output_StatusLabel.Text = e.UserState as string;
        }

        private void reader_button_Click(object sender, EventArgs e)
        {
            printToStatusLabel("下載選手資料中，請稍後");
            if (!repo.fetchParticipants())
            {
                MessageBox.Show("下載選手資料失敗，請重試");
                return;
            }
            printToStatusLabel("下載選手資料完成");

            var form = new ReaderForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
            form.Dispose();
        }

        private void refreshCOMPort()
        {
            this.COMToolStripMenuItem.DropDownItems.Clear();
            this.COMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重新整理ToolStripMenuItem});

            string[] ports = usbReader.getPortNames();
            foreach (string port in ports)
            {
                var item = new ToolStripMenuItem();
                item.Name = port + "ToolStripMenuItem";
                item.Size = new Size(152, 22);
                item.Text = port;
                item.Click += new EventHandler(this.COMPortConnect_Click);
                this.COMToolStripMenuItem.DropDownItems.Add(item);
            }
        }

        public void printToStatusLabel(string msg)
        {
            output_StatusLabel.Text = msg;
        }

        private void printScore_Click(object sender, EventArgs e)
        {
            //Components.ScoreGenerator.exportScoreToPDF();
            var f = new ScoreReviewForm();
            f.ShowDialog();
        }
    }
}
