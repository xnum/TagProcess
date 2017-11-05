using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using TagProcess.Forms;
using System.IO;
using ExcelDataReader;

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
            server.SetServerUrl(url);
            refreshCOMPort();
        }

        /// <summary>
        /// 跳出輸入伺服器網址視窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiServerUrl_Click(object sender, EventArgs e)
        {
            ServerUrlInputForm input = new ServerUrlInputForm();
            if (input.ShowDialog() == DialogResult.OK)
            {
                server.SetServerUrl(input.GetResult());
            }
        }

        /// <summary>
        /// 從伺服器下載並顯示選手資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowPartcipantsViewForm_Click(object sender, EventArgs e)
        {
            if(!server.IsConnected())
            {
                MessageBox.Show("請先設定伺服器網址");
                tsmiServerUrl_Click(null, null);
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
        private void btnPrintMailLabel_Click(object sender, EventArgs e)
        {
            if (!server.IsConnected())
            {
                MessageBox.Show("請先設定伺服器網址");
                tsmiServerUrl_Click(null, null);
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
        private void tsmiRefresh_Click(object sender, EventArgs e)
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
            foreach (ToolStripMenuItem t in tsmiComPort.DropDownItems)
            {
                t.Checked = false;
            }

            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if(usbReader.Connect(item.Text))
            {
                item.Checked = true;
            }
        }

        private void btnShowTagPairingForm_Click(object sender, EventArgs e)
        {
            if (!server.IsConnected())
            {
                MessageBox.Show("請先設定伺服器網址");
                tsmiServerUrl_Click(null, null);
                return;
            }

            if (!usbReader.IsConnected())
            {
                MessageBox.Show("讀卡機尚未設定PORT");
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

        private void tsmiLogFile_Click(object sender, EventArgs e) => Process.Start("log.txt");

        private void btnImportData_Click(object sender, EventArgs e)
        {
            if (!server.IsConnected())
            {
                MessageBox.Show("請先設定伺服器網址");
                tsmiServerUrl_Click(null, null);
                return;
            }

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select File";
            dialog.InitialDirectory = ".\\";
            dialog.Filter = "xls files (*.*)|*.xls";
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            using (var stream = File.Open(dialog.FileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do // 尋找資料表
                    {
                        if(reader.Name != "報名資料")
                            continue;

                        // 擷取第一行分析欄位
                        if(!reader.Read())
                        {
                            MessageBox.Show("錯誤：讀取第一行失敗");
                            return;
                        }

                        // 找到欄位名稱 -> 欄位index的對應
                        // mapTable紀錄 欄位index -> 資料名稱
                        // e.g. 姓名 -> 3 -> name
                        Dictionary<string, string> chi2engTable = new Dictionary<string, string> {
                            { "姓名", "name" },
                            { "團體名稱", "team_name" },
                            { "跑者編號", "race_id" },
                            { "出生日期", "birth" },
                            { "報名項目", "reg" },
                            { "組別", "type" },
                            { "手機", "phone" },
                            { "地址", "address" },
                            { "性別", "male" },
                            { "身分證字號", "sid" }
                        };
                        Dictionary<int, string> mapTable = new Dictionary<int, string>();
                        for(int i = 0; i < reader.FieldCount; ++i)
                        {
                            string headerStr = reader.GetString(i);
                            if(headerStr == null || headerStr.Length < 2)
                            {
                                continue;
                            }

                            // 以下針對各欄位名稱填表
                            if(chi2engTable.ContainsKey(headerStr))
                            {
                                mapTable[i] = chi2engTable[headerStr];
                            }
                        }

                        // 檢驗資料是否正確
                        if(chi2engTable.Count != mapTable.Count)
                        {
                            string missingCol = "";
                            foreach (var key in chi2engTable.Keys)
                                if (mapTable.ContainsValue(chi2engTable[key]))
                                    missingCol += chi2engTable[key] + "\n";
                            MessageBox.Show("錯誤：缺少欄位" + missingCol);
                            return;
                        }

                        // 開始轉換資料
                        List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();
                        HashSet<string> groups = new HashSet<string>();

                        while (reader.Read())
                        {
                            Dictionary<string, string> row = new Dictionary<string, string>();
                            string groupName = "###";
                            foreach(var index in mapTable.Keys)
                            {
                                string val = reader.GetValue(index)?.ToString();
                                if (val == null) val = "";
                                if (mapTable[index] == "reg")
                                    groupName = val + groupName;
                                else if (mapTable[index] == "type")
                                    groupName += val;
                                else
                                    row.Add(mapTable[index], val);
                            }

                            if (groupName == "###") break;

                            row.Add("group", groupName);
                            groups.Add(groupName);
                            data.Add(row);
                        }

                        string str = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                        string str_group = Newtonsoft.Json.JsonConvert.SerializeObject(groups);
                        Debug.WriteLine(str);
                        Debug.WriteLine(str_group);
                        if (true == repo.storeParticipants(str, str_group))
                            MessageBox.Show("上傳成功");
                        else
                            MessageBox.Show("上傳失敗");
                        return;
                    } while (reader.NextResult());

                    MessageBox.Show("錯誤：找不到資料表 [報名資料]");
                }
            }
        }

        private void btnShowReaderForm_Click(object sender, EventArgs e)
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
            this.tsmiComPort.DropDownItems.Clear();
            this.tsmiComPort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRefresh});

            string[] ports = usbReader.GetPortNames();
            foreach (string port in ports)
            {
                var item = new ToolStripMenuItem();
                item.Name = port + "ToolStripMenuItem";
                item.Size = new Size(152, 22);
                item.Text = port;
                item.Click += new EventHandler(this.COMPortConnect_Click);
                this.tsmiComPort.DropDownItems.Add(item);
            }
        }

        public void printToStatusLabel(string msg)
        {
            slblStatus.Text = msg;
        }

        private void printScore_Click(object sender, EventArgs e)
        {
            //Components.ScoreGenerator.exportScoreToPDF();
            //var f = new ScoreReviewForm();
            var f = new ScoreListForm();
            f.ShowDialog();
        }

        private void btnScoreReview_Click(object sender, EventArgs e)
        {
            var f = new ScoreReviewForm();
            f.ShowDialog();
        }
    }
}
