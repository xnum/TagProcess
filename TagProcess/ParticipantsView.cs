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
    public partial class ParticipantsView : Form
    {
        private Form parent = null;
        private Core core = null;

        public ParticipantsView(Form parentForm, Core c)
        {
            parent = parentForm;
            core = c;

            InitializeComponent();

            DataSet datas = core.getParticipants();
            DataTable table = datas.Tables["Table1"];
            foreach(DataRow row in table.Rows)
            {
                string age = (string)row["birth"];
                string male = (0 == (Int64)row["male"]) ? "男" : "女";
                long group_id = (long)row["group_id"];
                string group = (0 == group_id) ? "男1" : "男2";
                mainDGV.Rows.Add(row["id"], row["name"], age, male, group, row["tag_id"], row["race_id"], "編輯");
            }
            mainDGV.Refresh();
        }

        /// <summary>
        /// 視窗關閉時跳回主選單，目前只有主選單視窗可以打開此視窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParticipantsView_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }

        private void mainDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
                Debug.WriteLine(e.ColumnIndex + " , " + e.RowIndex);
            }
        }
    }
}
