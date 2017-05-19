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

        private void showEditForm(Participant p, Func<string> f)
        {
            var old_tag = p.tag_id;

            var form = new ParticipantsEditForm(p, f);

            var result = form.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }

            /* 
             * 在編輯視窗變更晶片時，還不確定是否真的要變更
             * 因此我們只檢查是否新晶片已經被使用
             * 接下來儲存時，要根據是否更換做Tags集合的維護使其同步
             */
            var val = form.retParticipant;
            if(val.tag_id != old_tag)
            {
                // 先前變更時已經檢查過是否已被使用
                // 現在新增一定會成功
                ParticipantHelper.tryAddTag(val.tag_id);

                // 刪除舊的晶片ID
                ParticipantHelper.cancelTag(old_tag);
            }
            if (val.needWriteBack())
            {
                // 更新時還會去尋找該選手，並對他的晶片ID做一次移除後新增的動作
                // 假設更新成功，就會對新晶片做一次移除再新增，不影響結果
                // 假設更新失敗，會跳出錯誤，且本地物件未被更新，則狀態不一致
                // 因此在失敗時做回復修正
                if(false == core.updateParticipant(val))
                {
                    if (val.tag_id != old_tag)
                    {
                        ParticipantHelper.cancelTag(val.tag_id); // 移除新的晶片
                        ParticipantHelper.tryAddTag(old_tag); // 新增舊的晶片
                    }
                }
                updateDataGridView();
            }
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

                showEditForm(core.participants[e.RowIndex], core.comport_get_tag);
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
                    showEditForm(core.participants[i], core.comport_get_tag);

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
                    textBox_tag_id.Text = tag;
                    // 感應到晶片，進行搜尋
                    for (int k = 0; k < core.participants.Count; ++k)
                    {
                        if (core.participants[k].tag_id == tag)
                        {
                            showEditForm(core.participants[k], core.comport_get_tag);

                            return;
                        }
                    }

                    MessageBox.Show("找不到該晶片所屬選手" + tag);

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
