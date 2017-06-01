using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

                inQueue[i] = new System.Collections.Concurrent.ConcurrentQueue<Cmd>();
            }

            
        }


        private void readerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int index = (int)e.Argument;
            string ip = textBox_ip[index].Text;
            runTcpClient(index, ip); // block here
        }

        private void readerWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var worker = (BackgroundWorker)sender;
            int index = (int)e.Result;
            textBox_status[index].Text = "DONE";
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
                if (got_cmd.type == Cmd.Type.GetTag)
                {
                    logging("Got tag " + got_cmd.data);
                    textBox_status[got_cmd.index].Text = got_cmd.data;
                    touchedView.Rows.Add("","",got_cmd.data,got_cmd.time.ToShortTimeString());
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
                    Cmd cmd = new Cmd();
                    cmd.type = Cmd.Type.SetDate;
                    inQueue[i].Enqueue(cmd);
                }

                if (refresh_count % 10 == 1) // 每1秒送一次取Tag
                {
                    Cmd cmd = new Cmd();
                    cmd.type = Cmd.Type.GetTag;
                    inQueue[i].Enqueue(cmd);
                }
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
    }
}
