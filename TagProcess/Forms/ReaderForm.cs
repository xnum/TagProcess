using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TagProcess
{
    public partial class ReaderForm : Form
    {
        delegate void SetTextCallback(string text, int index);

        private System.ComponentModel.BackgroundWorker[] readerWorker;
        private TextBox[] textBox_ip;
        private TextBox[] textBox_status;
        private TextBox[] textBox_time;
        private int refresh_count = 0;
        private string[] result = new string[] { "", "", ""};
        private int station_id = -1;

        private ParticipantsRepository repo = ParticipantsRepository.Instance;
        private TimeKeeper keeper = TimeKeeper.Instance;

        private IpicoClient[] clients = new IpicoClient[3];
        private Dictionary<string, string> start_time = null;

        public ReaderForm()
        {
            InitializeComponent();

            comboBox_station.Items.Clear();

            Dictionary<string, int> dict = new Dictionary<string, int>() { { "起點", 1 }, { "檢查點1", 2 }, { "檢查點2", 3 }, { "檢查點3", 4 }, { "終點", 99 } };
            comboBox_station.DataSource = new BindingSource(dict, null);
            comboBox_station.DisplayMember = "Key"; 
            comboBox_station.ValueMember = "Value";

            textBox_ip = new TextBox[] { textBox_reader_ip1, textBox_reader_ip2, textBox_reader_ip3 };
            textBox_status = new TextBox[] {  };
            textBox_time = new TextBox[] { };

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
            
        }

        private void SetText(string text, int index)
        {
            if (textBox_log.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                Invoke(d, new object[] { text , index });
            }
            else
            {
                textBox_log.AppendText("Reader " + index + ":" + text + "\r\n");
            }
        }

        private void readerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int index = (int)e.Argument;
            e.Result = index;
            string ip = textBox_ip[index].Text;
            clients[index] = new IpicoClient(ip);
            clients[index].Log += (string msg) => { SetText(msg, index); };
            if (!clients[index].connect())
            {
                return;
            }

            clients[index].run();
        }

        private void readerWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void button_conn0_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int index = int.Parse((string)btn.Tag);
            readerWorker[index].RunWorkerAsync(index);
        }

        private void refresh_timer_Tick(object sender, EventArgs e)
        {
            refresh_count++;
            label_localtime.Text = DateTime.Now.ToString();

            for(int i = 0; i < 3; ++i)
            {
                if (clients[i] == null || !clients[i].isConnected()) continue;

                IPXCmd got_cmd = null;
                while(clients[i].TryGet(out got_cmd))
                {
                    if (got_cmd.type == IPXCmd.Type.GetTag)
                    {
                        keeper.addData(station_id, got_cmd);

                        /*
                        FileLogger.Instance.logPacket(String.Format("{0}\t{1}\t{2}\t{3}", 
                            station_id, got_cmd.data, got_cmd.time, (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000));
                        if (!keeper.addData(station_id, got_cmd)) // 新增失敗就不做以下動作
                            continue;
                        textBox_status[i].Text = got_cmd.data;
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
                        touchedView.Rows.Add(got_cmd.data, race_id, name, group, got_cmd.time.ToLongTimeString(), stime);
                        
                        System.Media.SystemSounds.Beep.Play(); // 播放音效
                        */
                    }

                    /*
                    if (got_cmd.type == IPXCmd.Type.GetDate || got_cmd.type == IPXCmd.Type.SetDate)
                    {
                        textBox_time[i].Text = got_cmd.time.ToString();
                    }
                    */
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

            if (refresh_count % 100 == 1) // 每10秒提醒一次 該發送資料了
                keeper.notifyTimeout();

            if (refresh_count % 300 == 1)
            {
                //start_time = keeper.fetchStartRecords();
            }

            while(touchedView.Rows.Count >= 100)
                touchedView.Rows.RemoveAt(0);
            //if(refresh_count % 10 == 1)touchedView.Refresh();

            label_tagged.Text = keeper.GetTaggedP().ToString();
            label_total.Text = keeper.GetTotalP().ToString();
            label_upload.Text = keeper.GetUploadP().ToString();
            label_buffered.Text = keeper.GetBufferedP().ToString();
        }

        private bool start()
        {
            int station_n = 0;// comboBox_checkpoint.SelectedIndex;
            if (station_n < 0)
            {
                MessageBox.Show("未選擇檢查點");
                return false;
            }

            List<int> groups_n = new List<int>();
            List<RaceGroups> g = repo.helper.getGroups();
            /*
            foreach (string i in checkedListBox_group.CheckedItems)
            {
                foreach (var j in g)
                    if (j.reg == i)
                        groups_n.Add(j.id);
            }
            */

            if (station_n <= 1 && groups_n.Count < 0) // 起點與單點模式
            {
                MessageBox.Show("未選擇起跑組別");
                return false;
            }

            station_id = station_n;

            int max_round = -1;
            int limit_sec = 3;
            if (station_n == 0)
            {
                try
                {
                    //max_round = Int32.Parse(textBox_maxRound.Text);
                }
                catch
                {
                    MessageBox.Show("最大圈數輸入錯誤");
                    return false;
                }

                try
                {
                    //limit_sec = Int32.Parse(textBox_limitSecond.Text);
                }
                catch
                {
                    MessageBox.Show("限制感應秒數輸入錯誤");
                    return false;
                }
            }

            return keeper.setStartCompetition(station_n, max_round, groups_n, limit_sec);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> ids = new List<string>();
            string msg = "";
            for(int i = 0; i < dgv_group.Rows.Count; ++i)
            {
                DataGridViewCheckBoxCell chkbox = (DataGridViewCheckBoxCell)dgv_group.Rows[i].Cells[0];
                if(chkbox != null && (bool)chkbox.FormattedValue == true)
                {
                    string id = dgv_group.Rows[i].Cells[1].Value.ToString();
                    ids.Add(id);
                    msg += id +":"+dgv_group.Rows[i].Cells[2].Value.ToString() + "\r\n";
                }
            }

            DialogResult res = MessageBox.Show(msg, "選取組別", MessageBoxButtons.YesNo);
            
        }

        private void comboBox_station_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_station.SelectedValue is int)
            {
                station_id = (int)comboBox_station.SelectedValue;
            }
            else
            {
                var v = (KeyValuePair<string, int>)comboBox_station.SelectedValue;
                station_id = v.Value;
            }
            SetText("Station ID = " + station_id, 0);
        }
    }
}
