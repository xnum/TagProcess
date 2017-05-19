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
using Newtonsoft.Json;

namespace TagProcess
{
    public partial class ParticipantsViewForm : Form
    {
        private Form parent = null;
        private Core core = null;

        /* Helper Functions*/
        private void updateDataGridView()
        {
            mainDGV.Rows.Clear();
            foreach (var row in core.participants)
            {
                mainDGV.Rows.Add(row.id, row.name, row.age, row.male_s, row.group, row.tag_id, row.race_id, "編輯");
            }
            mainDGV.Refresh();
        }

        public ParticipantsViewForm(Form parentForm, Core c)
        {
            parent = parentForm;
            core = c;

            InitializeComponent();

            updateDataGridView();
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

        /// <summary>
        /// 當編輯按鈕被按下時，跳出對應列選手的編輯視窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                Debug.WriteLine(e.ColumnIndex + " , " + e.RowIndex);

                var form = new ParticipantsEditForm(core.participants[e.RowIndex], core.comport_get_tag);
                
                var result = form.ShowDialog();

                if (result != DialogResult.OK)
                {
                    return;
                }

                var val = form.retParticipant;
                if (val.needWriteBack())
                {
                    core.updateParticipant(val);
                    updateDataGridView();
                }
            }
        }
    }
}
