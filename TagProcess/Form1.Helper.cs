using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TagProcess
{
    public partial class Form1 : Form
    {
        private void refreshCOMPort()
        {
            this.COMToolStripMenuItem.DropDownItems.Clear();
            this.COMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重新整理ToolStripMenuItem});

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
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

    }
}
