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
    public partial class ServerUrlInputForm : Form
    {
        public ServerUrlInputForm()
        {
            InitializeComponent();
        }

        public string GetResult()
        {
            return input_ServerUrl.Text;
        }
    }
}
