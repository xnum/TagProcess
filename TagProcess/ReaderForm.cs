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

            
        }


        private void readerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = e.Argument;
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
    }
}
