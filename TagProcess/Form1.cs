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
                MessageBox.Show("尚未設定完成");
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


    }
}
