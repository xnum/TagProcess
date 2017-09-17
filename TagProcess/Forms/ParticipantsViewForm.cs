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
        private ParticipantsRepository repo = ParticipantsRepository.Instance;
        private TagUSBReader usbReader = TagUSBReader.Instance;

        /* Helper Functions*/
        private void refreshDataGridView()
        {
            mainDGV.Rows.Clear();
            foreach (var row in repo.participants)
            {
                mainDGV.Rows.Add(row.id, row.name, row.age, row.male_s, row.group, row.tag_id, row.race_id, row.team_name, "編輯");
            }
            mainDGV.Refresh();
        }

        private void showEditForm(Participant p)
        {
            var old_tag = p.tag_id;

            var form = new ParticipantsEditForm(p);

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
                repo.helper.tryAddTag(val.tag_id);

                // 刪除舊的晶片ID
                repo.helper.cancelTag(old_tag);
            }
            if (val.needWriteBack())
            {
                // 更新時還會去尋找該選手，並對他的晶片ID做一次移除後新增的動作
                // 假設更新成功，就會對新晶片做一次移除再新增，不影響結果
                // 假設更新失敗，會跳出錯誤，且本地物件未被更新，則狀態不一致
                // 因此在失敗時做回復修正
                if (false == repo.uploadParticipant(val))
                {
                    if (val.tag_id != old_tag)
                    {
                        repo.helper.cancelTag(val.tag_id); // 移除新的晶片
                        repo.helper.tryAddTag(old_tag); // 新增舊的晶片
                    }
                }
                else
                { // 上傳成功，更新該選手在DataGridView裡面的資料
                    refreshDataGridView();
                    int id = val.id;
                    for(int i = 0; i < mainDGV.Rows.Count; ++i)
                    {
                        if ((int)mainDGV.Rows[i].Cells[0].Value == id)
                        {
                            mainDGV.Rows[i].Cells[1].Value = val.name;
                            mainDGV.Rows[i].Cells[2].Value = val.age;
                            mainDGV.Rows[i].Cells[3].Value = val.male_s;
                            mainDGV.Rows[i].Cells[4].Value = val.group;
                            mainDGV.Rows[i].Cells[5].Value = val.tag_id;
                            mainDGV.Rows[i].Cells[6].Value = val.race_id;
                        }
                    }
                }
            }
        }

        public ParticipantsViewForm()
        {
            InitializeComponent();

            refreshDataGridView();
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
                showEditForm(repo.participants[e.RowIndex]);
            }
        }

        /// <summary>
        /// 依號碼布號碼搜尋按紐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void search_by_race_id_button_Click(object sender, EventArgs e)
        {
            var result = repo.findByRaceID(textBox_race_id.Text);

            if (result == null)
            {
                MessageBox.Show("找不到該編號");
                return;
            }

            showEditForm(result);
        }

        /// <summary>
        /// 以晶片ID搜尋功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchByTagIdButtonClick(object sender, EventArgs e)
        {
            string tag = String.Empty;

            if(!usbReader.IsConnected())
            {
                MessageBox.Show("讀卡機尚未連接");
                return;
            }

            for (int i = 0; i < 30; ++i)
            {
                try
                {
                    textBox_tag_id.Text = "等候感應中，剩餘" + (30 - i) / 2 + "秒";
                    tag = usbReader.ReadTag();
                    if (tag != String.Empty)
                        break;
                }
                catch (InvalidOperationException)
                {
                    textBox_tag_id.Text = "讀卡機已斷線，請回主選單重新設定";
                    return;
                }
            }

            if (tag == String.Empty)
            {
                textBox_tag_id.Text = "感應逾時，請重試";
                return;
            }

            textBox_tag_id.Text = tag;
            var result = repo.findByTag(tag);
            if (tag == null)
            {
                MessageBox.Show("找不到該晶片所屬選手" + tag);
                return;
            }

            showEditForm(result);
        }
    }
}
