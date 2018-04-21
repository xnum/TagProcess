using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TagProcess
{
    public partial class ReaderForm : MetroFramework.Forms.MetroForm
    {
        delegate void SetTextNCallback(string text, int index);
        delegate void SetText0Callback(string text);

        private System.ComponentModel.BackgroundWorker[] readerWorker;
        private MetroTextBox[] textBox_ip;
        private int refresh_count = 0;
        private string[] result = new string[] { "", "", ""};
        private int station_id = -1;

        private ParticipantsRepository repo = ParticipantsRepository.Instance;
        private TimeKeeper keeper = TimeKeeper.Instance;

        private IpicoClient[] clients = new IpicoClient[3];
        private Dictionary<string, string> start_time;

        public ReaderForm()
        {
            InitializeComponent();

            comboBox_station.Items.Clear();

            Dictionary<string, int> dict = new Dictionary<string, int>() { { "起點", 1 }, { "終點", 99 } };
            comboBox_station.DataSource = new BindingSource(dict, null);
            comboBox_station.DisplayMember = "Key"; 
            comboBox_station.ValueMember = "Value";

            textBox_ip = new MetroTextBox[] { textBox_reader_ip1, textBox_reader_ip2, textBox_reader_ip3 };

            readerWorker = new BackgroundWorker[3];
            for (int i = 0; i < this.readerWorker.Length; ++i)
            {
                readerWorker[i] = new BackgroundWorker();
                readerWorker[i].DoWork += new DoWorkEventHandler(readerWorker_DoWork);
                readerWorker[i].RunWorkerCompleted += new RunWorkerCompletedEventHandler(readerWorker_RunWorkerCompleted);
            }

            HashSet<string> seenGroup = new HashSet<string>();
            foreach(RaceGroups item in repo.helper.getGroups())
            {
                dgv_group.Rows.Add(false, item.id, item.name, "");
            }

            keeper.Log += SetText0;

            keeper.Init(1);
        }

        private void SetTextN(string text, int index)
        {
            try
            {
                if (textBox_log.InvokeRequired)
                {
                    SetTextNCallback d = new SetTextNCallback(SetTextN);
                    Invoke(d, new object[] { text, index });
                }
                else
                {
                    textBox_log.AppendText("Reader " + index + ":" + text + "\r\n");
                }
            }
            catch(Exception ex)
            {
                FileLogger.Instance.log(ex.Message + ex.StackTrace);
            }
        }

        private void SetText0(string text)
        {
            try
            {
                if (textBox_log.InvokeRequired)
                {
                    SetText0Callback d = new SetText0Callback(SetText0);
                    Invoke(d, new object[] { text });
                }
                else
                {
                    textBox_log.AppendText(text + "\r\n");
                }
            }
            catch (Exception ex)
            {
                FileLogger.Instance.log(ex.Message + ex.StackTrace);
            }
        }


        private void readerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int index = (int)e.Argument;
            e.Result = index;
            string ip = textBox_ip[index].Text;
            

            clients[index] = new IpicoClient(ip);
            clients[index].Log += (string msg) => { SetTextN(msg, index); };
            if (!clients[index].connect())
            {
                return;
            }

            clients[index].run();          

            SetTextN("執行緒已終止", index);

            e.Result = index;
        }

        private void readerWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            int index = (int)e.Result;
            textBox_ip[index].BackColor = Color.FromArgb(255, 192, 192);
        }

        private void button_conn0_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = int.Parse((string)btn.Tag);
            if (!readerWorker[index].IsBusy)
            {
                textBox_ip[index].BackColor = Color.FromArgb(192, 255, 192);
                readerWorker[index].RunWorkerAsync(index);
            }
            else
                SetTextN("忙碌中...", index);
        }

        private void refresh_timer_Tick(object sender, EventArgs e)
        {
            refresh_count++;
            label_localtime.Text = DateTime.Now.ToLongTimeString();

            for(int i = 0; i < 3; ++i)
            {
                if (clients[i] == null || !clients[i].isConnected()) continue;

                IPXCmd got_cmd = null;
                while(clients[i].TryGet(out got_cmd))
                {
                    if (got_cmd.type == IPXCmd.Type.GetTag)
                    {
                        var result = keeper.addData(station_id, got_cmd);
                        // 新增失敗就不做以下動作
                        if(result == TimeKeeper.AddResult.Invalid || 
                           result == TimeKeeper.AddResult.DefeatDup ||
                           result == TimeKeeper.AddResult.NormalDup)
                            continue;
                        
                        string race_id = "";
                        string name = "";
                        string group = "";
                        Participant p = repo.findByTag(got_cmd.data);
                        if (p != null)
                        {
                            race_id = p.race_id;
                            name = p.name;
                            group = p.group;
                        }
                        string stime = start_time.ContainsKey(got_cmd.data) ? start_time[got_cmd.data] : "查無資料";

                        if (station_id == 1) stime = "";
                        
                        if (result == TimeKeeper.AddResult.DefeatFirst)
                        {
                            stime = "組別錯誤";
                        }

                        MetroGrid targetView = (result != TimeKeeper.AddResult.DefeatFirst) ? touchedView : faultView;

                        try
                        {
                            bool found = false;
                            for(int j = 0; j < targetView.Rows.Count && !found; ++j)
                            {
                                if(targetView.Rows[j].Cells[0].FormattedValue.ToString() == got_cmd.data)
                                {
                                    targetView.Rows[j].Cells[4].Value = got_cmd.time.ToLongTimeString();
                                    found = true;
                                    break;
                                }
                            }

                            if(!found)
                                targetView.Rows.Add(got_cmd.data, race_id, name, group, got_cmd.time.ToLongTimeString(), stime);

                            targetView.FirstDisplayedScrollingRowIndex = targetView.RowCount - 1;
                        }
                        catch(Exception ex)
                        {
                            SetText0(ex.Message);
                        }
                        
                        System.Media.SystemSounds.Beep.Play(); // 播放音效
                    }
                }

                if (refresh_count % 100 == 1) // 每10秒設定一次時間
                {
                    clients[i].Put(new IPXCmd(IPXCmd.Type.SetDate));
                }

                if (refresh_count % 50 == 1) // 每5秒取得一次時間
                {
                    clients[i].Put(new IPXCmd(IPXCmd.Type.GetDate));
                }
            }

            if (refresh_count % 70 == 1) // 每7秒提醒一次 該發送資料了
                keeper.notifyTimeout();

            if (refresh_count % 300 == 1)
            {
                var v = keeper.fetchStartRecords();
                if (v != null) start_time = v;
            }

            label_tagged.Text = keeper.GetTagCount().ToString();
            label_total.Text = keeper.GetTotalCount().ToString();
            label_upload.Text = keeper.GetUploadedCount().ToString();
            label_buffered.Text = keeper.GetBufferedCount().ToString();
            label_dup.Text = keeper.GetDupCount().ToString();           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            string msg = "";
            for(int i = 0; i < dgv_group.Rows.Count; ++i)
            {
                DataGridViewCheckBoxCell chkbox = (DataGridViewCheckBoxCell)dgv_group.Rows[i].Cells[0];
                if(chkbox != null && (bool)chkbox.FormattedValue == true)
                {
                    string id = dgv_group.Rows[i].Cells[1].Value.ToString();
                    ids.Add(Int32.Parse(id));
                    msg += id +":"+dgv_group.Rows[i].Cells[2].Value.ToString() + "\r\n";
                }
            }

            DialogResult res = MessageBox.Show(msg, "選取組別", MessageBoxButtons.YesNo);
            
            if(res == DialogResult.Yes)
            {
                if(true == keeper.setStartCompetition(ids))
                {
                    for (int i = 0; i < dgv_group.Rows.Count; ++i)
                    {
                        if (ids.Contains(Int32.Parse(dgv_group.Rows[i].Cells[1].Value.ToString())))
                        {
                            DataGridViewCheckBoxCell chkbox = (DataGridViewCheckBoxCell)dgv_group.Rows[i].Cells[0];
                            chkbox.FlatStyle = FlatStyle.Flat;
                            chkbox.Style.ForeColor = Color.DarkGray;
                            chkbox.Value = false;
                            chkbox.ReadOnly = true;
                            dgv_group.Rows[i].Cells[3].Value = DateTime.Now.ToString();
                        }
                    }
                }
            }
        }

        private void comboBox_station_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox_station.Checked) return;
            if (comboBox_station.SelectedValue is int)
            {
                set_station_id((int)comboBox_station.SelectedValue);
            }
            else
            {
                var v = (KeyValuePair<string, int>)comboBox_station.SelectedValue;
                set_station_id(v.Value);
            }

        }

        private void ReaderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            keeper.Log -= SetText0;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker wk = sender as BackgroundWorker;
            while (!wk.CancellationPending)
            {
                SetTextN(DateTime.Now.ToString(), 0);
                string res = keeper.triggerServer();
                wk.ReportProgress(0, res);
                Thread.Sleep(8000);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Tag.ToString() == "0" && !backgroundWorker1.IsBusy)
            {
                SetTextN("啟動背景工作", 0);
                backgroundWorker1.RunWorkerAsync();
                btn.Tag = "1";
            }
            else
            {
                SetTextN("取消背景工作", 0);
                backgroundWorker1.CancelAsync();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button2.Tag = "0";
            SetTextN("背景工作已停止", 0);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if(e.UserState != null)
            {
                SetTextN(e.UserState as string, 0);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_station.Checked == false)
                comboBox_station_SelectedIndexChanged(null, null);
            else
                textBox_station_TextChanged(null, null);
        }

        private void textBox_station_TextChanged(object sender, EventArgs e)
        {
            if (checkBox_station.Checked == false) return;

            try
            {
                set_station_id(Int32.Parse(textBox_station.Text));
            }
            catch(Exception ex)
            {
                return;
            }
        }

        private void set_station_id(int id)
        {
            station_id = id;
            SetTextN("Station ID = " + station_id, 0);
            keeper.Init(station_id);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            keeper.ClearTagged();
            touchedView.Rows.Clear();
            faultView.Rows.Clear();
        }

        private void ReaderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(backgroundWorker1.IsBusy)
            {
                backgroundWorker1.CancelAsync();
                SetText0("等待停止中，無法關閉視窗");
                e.Cancel = true;
                return;
            }

            for (int i = 0; i < readerWorker.Length; ++i)
            {
                if(readerWorker[i].IsBusy)
                {
                    clients[i]?.disconnect();
                }
            }

            for (int i = 0; i < readerWorker.Length; ++i)
            {
                if (readerWorker[i].IsBusy)
                {
                    SetTextN("等待停止中，無法關閉視窗", i);
                    e.Cancel = true;
                }
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            string msg = "";
            for (int i = 0; i < dgv_group.Rows.Count; ++i)
            {
                DataGridViewCheckBoxCell chkbox = (DataGridViewCheckBoxCell)dgv_group.Rows[i].Cells[0];
                if (chkbox != null && (bool)chkbox.FormattedValue == true)
                {
                    string id = dgv_group.Rows[i].Cells[1].Value.ToString();
                    ids.Add(Int32.Parse(id));
                    msg += id + ":" + dgv_group.Rows[i].Cells[2].Value.ToString() + "\r\n";
                }
            }

            SetText0("設定起跑組別為：" + msg);
            keeper.setStartingGroups(ids);
        }
    }
}
