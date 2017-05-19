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

        /// <summary>
        /// 依號碼布號碼搜尋按紐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void search_by_race_id_button_Click(object sender, EventArgs e)
        {
            string race_id = textBox_race_id.Text;
            for(int i = 0; i < core.participants.Count; ++i)
            {
                if(core.participants[i].race_id == race_id)
                {
                    var form = new ParticipantsEditForm(core.participants[i], core.comport_get_tag);

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

                    return;
                }
            }

            MessageBox.Show("找不到該編號");
        }

        /// <summary>
        /// 以晶片ID搜尋功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void search_by_tag_id_button_Click(object sender, EventArgs e)
        {
            string tag = String.Empty;
            textBox_tag_id.Text = "等候感應中";
            for (int i = 0; i < 30; ++i)
            {
                try
                {
                    tag = core.comport_get_tag();
                    if (tag == String.Empty)
                        continue;

                    // 感應到晶片，進行搜尋
                    for (int k = 0; k < core.participants.Count; ++k)
                    {
                        if (core.participants[k].race_id == tag)
                        {
                            var form = new ParticipantsEditForm(core.participants[k], core.comport_get_tag);

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

                            return;
                        }
                    }

                    MessageBox.Show("找不到該晶片所屬選手");

                    return;
                }
                catch (InvalidOperationException)
                {
                    textBox_tag_id.Text = "讀卡機已斷線，請回主選單重新設定";
                    return;
                }
            }
            textBox_tag_id.Text = "感應逾時，請重試";
        }
    }
}
