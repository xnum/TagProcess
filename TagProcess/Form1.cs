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


namespace TagProcess
{
    public partial class Form1 : Form
    {
        private Core core = null;
        private ParticipantsView pv = null;

        public Form1()
        {
            InitializeComponent();

            core = new Core(logging);
            
            refreshCOMPort();
        }

        private void refreshCOMPort()
        {
            this.COMToolStripMenuItem.DropDownItems.Clear();
            this.COMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重新整理ToolStripMenuItem});

            string[] ports = SerialPort.GetPortNames();
            foreach(string port in ports)
            {
                var item = new ToolStripMenuItem();
                item.Name = port + "ToolStripMenuItem";
                item.Size = new Size(152, 22);
                item.Text = port;
                item.Click += new EventHandler(this.COMPortConnect_Click);
                this.COMToolStripMenuItem.DropDownItems.Add(item);
            }
        }

        public void logging(int level, string msg)
        {
            output_StatusLabel.Text = msg;

            Debug.WriteLine(msg);
        }

        private void 伺服器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServerUrlInputForm input = new ServerUrlInputForm();
            if (input.ShowDialog() == DialogResult.OK)
            {
                core.setServerUrl(input.GetResult());
                logging(0, "已設定伺服器網址");
                
            }
        }

        private void partcipants_view_button_Click(object sender, EventArgs e)
        {
            if(!core.checkServerStatus())
            {
                MessageBox.Show("請先設定伺服器網址");
                伺服器ToolStripMenuItem_Click(null, null);
                return;
            }

            logging(0, "下載選手資料中，請稍後");
            if(!core.loadParticipants())
            {
                MessageBox.Show("下載選手資料失敗，請重試");
                return;
            }
            logging(0, "下載選手資料完成");
            pv = new ParticipantsView(this, core);
            this.Hide();
            pv.Show();
        }

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
            core.gen_mail_pdf();
        }

        private void 重新整理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshCOMPort();
        }

        private void COMPortConnect_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem t in COMToolStripMenuItem.DropDownItems)
            {
                t.Checked = false;
            }

            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if(core.connect_COMPort(item.Text))
            {
                item.Checked = true;
            }
        }
    }
}
