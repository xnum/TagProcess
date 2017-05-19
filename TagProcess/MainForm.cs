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
    public partial class MainForm : Form
    {
        private Core core = null;
        private ParticipantsViewForm pv = null;

        public MainForm()
        {
            InitializeComponent();

            core = new Core(logging);
            
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
                core.setServerUrl(input.GetResult());
                logging(0, "已設定伺服器網址");
                
            }
        }

        /// <summary>
        /// 從伺服器下載並顯示選手資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void partcipants_view_button_Click(object sender, EventArgs e)
        {
            if(!core.checkServerStatus())
            {
                MessageBox.Show("請先設定伺服器網址");
                伺服器ToolStripMenuItem_Click(null, null);
                return;
            }

            if(!core.is_comport_opened())
            {
                MessageBox.Show("請先設定讀卡機COM Port");
                return;
            }

            logging(0, "下載選手資料中，請稍後");
            if(!core.loadParticipants())
            {
                MessageBox.Show("下載選手資料失敗，請重試");
                return;
            }
            logging(0, "下載選手資料完成");
            pv = new ParticipantsViewForm(this, core);
            this.Hide();
            pv.Show();
        }

        /// <summary>
        /// 從伺服器下載選手資料並產生PDF檔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            logging(0, "下載選手資料完成");
            core.gen_mail_pdf();
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
            if(core.connect_comport(item.Text))
            {
                item.Checked = true;
            }
        }
    }
}
