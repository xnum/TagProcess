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
        private System.ComponentModel.BackgroundWorker[] readerWorker;
        private TextBox[] textBox_ip;
        private TextBox[] textBox_status;
        private TextBox[] textBox_time;
        private int refresh_count = 0;
        private string[] result = new string[] { "", "", ""};
        private int station_id = -1;
        private FileStream bakFile;
        private StreamWriter bakWriter;
        private HashSet<string> seenTag = new HashSet<string>();
        private List<Cmd> tagBuff = new List<Cmd>();
        private ParticipantsRepository repo = ParticipantsRepository.Instance;
        private TimeKeeper keeper = TimeKeeper.Instance;

        public ReaderForm()
        {
            InitializeComponent();
            bakFile = new FileStream("tag.txt", FileMode.Append, FileAccess.Write, FileShare.Read, bufferSize: 4096);
            bakWriter = new StreamWriter(bakFile, Encoding.ASCII);

            textBox_ip = new TextBox[] { textBox_ip0, textBox_ip1, textBox_ip2 };
            textBox_status = new TextBox[] { textBox_status0, textBox_status1, textBox_status2 };
            textBox_time = new TextBox[] { textBox_time0, textBox_time1, textBox_time2 };

            readerWorker = new BackgroundWorker[3];
            for (int i = 0; i < this.readerWorker.Length; ++i)
            {
                readerWorker[i] = new BackgroundWorker();
                readerWorker[i].DoWork += new DoWorkEventHandler(readerWorker_DoWork);
                readerWorker[i].RunWorkerCompleted += new RunWorkerCompletedEventHandler(readerWorker_RunWorkerCompleted);

                inQueue[i] = new System.Collections.Concurrent.ConcurrentQueue<Cmd>();
            }

            foreach(var item in repo.helper.getGroups())
            {
                checkedListBox_group.Items.Add(item.name);
            }
            
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                    bakWriter.Dispose();
                    bakFile.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        private void readerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int index = (int)e.Argument;
            e.Result = index;
            string ip = textBox_ip[index].Text;
            result[index] = "已連線";
            result[index] = runTcpClient(index, ip); // block here
        }

        private void readerWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            int index = (int)e.Result;
            textBox_status[index].Text = result[index];
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

            Cmd got_cmd = null;
            while(outQueue.TryDequeue(out got_cmd))
            {
                if (station_id < 0) continue; /* 尚未開始 */

                if (got_cmd.type == Cmd.Type.GetTag)
                {
                    if (!seenTag.Add(got_cmd.data)) continue;

                    logging("Got tag " + got_cmd.data);

                    bakWriter.WriteLine(got_cmd.data);
                    tagBuff.Add(got_cmd);

                    textBox_status[got_cmd.index].Text = got_cmd.data;
                    string race_id = "編號";
                    string name = "姓名";
                    string group = "組別";
                    Participant p = repo.findByTag(got_cmd.data);
                    if(p != null)
                    {
                        race_id = p.race_id;
                        name = p.name;
                        group = p.group;
                    }
                    touchedView.Rows.Add(got_cmd.data, race_id,name,group,got_cmd.time.ToShortTimeString());
                }

                if (got_cmd.type == Cmd.Type.GetDate || got_cmd.type == Cmd.Type.SetDate)
                {
                    logging("Got time " + got_cmd.time);
                    textBox_time[got_cmd.index].Text = got_cmd.time.ToString();
                }
            }

            for (int i = 0; i < 3; ++i) 
            {
                if (!readerWorker[i].IsBusy) continue;

                if (refresh_count % 100 == 1) // 每10秒設定一次時間
                {
                    inQueue[i].Enqueue(new Cmd(Cmd.Type.SetDate));
                }

                if (refresh_count % 50 == 1) // 每5秒取得一次時間
                {
                    inQueue[i].Enqueue(new Cmd(Cmd.Type.GetDate));
                }
            }

            if (refresh_count % 30 == 1) // 每3秒上傳一次資料
            {
                if (tagBuff.Count == 0) return; 
                if (keeper.uploadTagData(station_id, tagBuff))
                    tagBuff.Clear();
            }
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
            if (batch_n < 0)
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

            if (groups_n.Count < 0)
            {
                MessageBox.Show("未選擇起跑組別");
                return false;
            }

            station_id = station_n;

            return keeper.setStartCompetition(station_n, batch_n, groups_n);
        }
    }
}
