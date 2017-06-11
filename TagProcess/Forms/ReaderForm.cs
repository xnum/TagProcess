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

        private HashSet<string> seenTag = new HashSet<string>();
        private ParticipantsRepository repo = ParticipantsRepository.Instance;
        private TimeKeeper keeper = TimeKeeper.Instance;

        private IpicoClient[] clients = new IpicoClient[3];

        public ReaderForm()
        {
            InitializeComponent();

            textBox_ip = new TextBox[] { textBox_ip0, textBox_ip1, textBox_ip2 };
            textBox_status = new TextBox[] { textBox_status0, textBox_status1, textBox_status2 };
            textBox_time = new TextBox[] { textBox_time0, textBox_time1, textBox_time2 };

            readerWorker = new BackgroundWorker[3];
            for (int i = 0; i < this.readerWorker.Length; ++i)
            {
                readerWorker[i] = new BackgroundWorker();
                readerWorker[i].DoWork += new DoWorkEventHandler(readerWorker_DoWork);
                readerWorker[i].RunWorkerCompleted += new RunWorkerCompletedEventHandler(readerWorker_RunWorkerCompleted);
            }

            foreach(var item in repo.helper.getGroups())
            {
                checkedListBox_group.Items.Add(item.name);
            }
            
        }

        private void SetText(string text, int index)
        {
            if (textBox_status[index].InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                Invoke(d, new object[] { text , index });
            }
            else
            {
                textBox_status[index].Text = text;
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
            textBox_localtime.Text = DateTime.Now.ToString();

            for(int i = 0; i < 3; ++i)
            {
                if (clients[i] == null || !clients[i].isConnected()) continue;

                IPXCmd got_cmd = null;
                while(clients[i].TryGet(out got_cmd))
                {
                    if (got_cmd.type == IPXCmd.Type.GetTag)
                    {
                        if (!seenTag.Add(got_cmd.data)) continue;

                        keeper.addData(got_cmd);
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
                        touchedView.Rows.Add(got_cmd.data, race_id, name, group, got_cmd.time.ToLongTimeString());
                    }

                    if (got_cmd.type == IPXCmd.Type.GetDate || got_cmd.type == IPXCmd.Type.SetDate)
                    {
                        textBox_time[i].Text = got_cmd.time.ToString();
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

            while(touchedView.Rows.Count >= 15)
                touchedView.Rows.RemoveAt(0);
            touchedView.Refresh();
        }

        private void comboBox_checkpoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if(cb.SelectedIndex == 0)
            {
                comboBox_batch.Enabled = true;
                checkedListBox_group.Enabled = true;
            }
            else
            {
                comboBox_batch.Enabled = false;
                checkedListBox_group.Enabled = false;
            }
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            if (start_button.Text == "開始")
            {
                if (!start()) return;

                seenTag = new HashSet<string>();
                start_button.Text = "停止";
                comboBox_checkpoint.Enabled = false;
                comboBox_batch.Enabled = false;
                checkedListBox_group.Enabled = false;
            }
            else
            {
                start_button.Text = "開始";
                comboBox_checkpoint.Enabled = true;
                comboBox_batch.Enabled = true;
                checkedListBox_group.Enabled = true;
            }

        }

        private bool start()
        {
            int station_n = comboBox_checkpoint.SelectedIndex;
            if (station_n < 0)
            {
                MessageBox.Show("未選擇檢查點");
                return false;
            }

            int batch_n = comboBox_batch.SelectedIndex;
            if (station_n == 0 && batch_n < 0)
            {
                MessageBox.Show("未選擇起跑批次");
                return false;
            }

            List<int> groups_n = new List<int>();
            List<RaceGroups> g = repo.helper.getGroups();
            foreach (string i in checkedListBox_group.CheckedItems)
            {
                foreach (var j in g)
                    if (j.name == i)
                        groups_n.Add(j.id);
            }

            if (station_n == 0 && groups_n.Count < 0)
            {
                MessageBox.Show("未選擇起跑組別");
                return false;
            }

            station_id = station_n;

            return keeper.setStartCompetition(station_n, batch_n, groups_n);
        }
    }
}
