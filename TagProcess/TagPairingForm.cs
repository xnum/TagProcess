using System;
using System.Collections.Concurrent;
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
    public partial class TagPairingForm : Form
    {
        private ParticipantsRepository repo = ParticipantsRepository.Instance;
        private TagUSBReader usbReader = TagUSBReader.Instance;
        private BlockingCollection<string> incomingTags = null; // ConcurrentQueue
        private string lastTag = String.Empty;
        public TagPairingForm()
        {
            InitializeComponent();

            foreach (var p in repo.participants)
            {
                pairDGV.Rows.Add(p.tag_id, p.race_id, p.name, p.group);
            }

            pairDGV.Refresh();
        }

        private void start_pair_button_Click(object sender, EventArgs e)
        {
            incomingTags = new BlockingCollection<string>(50);
            consumer_timer.Enabled = true;
            getTagWorker.RunWorkerAsync();
            statusLabel.Text = "已開始接收讀卡機資料";
            start_pair_button.Enabled = false;
            stop_pair_button.Enabled = true;
        }

        /// <summary>
        /// 扮演Producer角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getTagWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            while (!worker.CancellationPending)
            {
                string tag = String.Empty;
                try
                {
                    tag = usbReader.readTag();
                }
                catch (InvalidOperationException)
                {
                    worker.CancelAsync();
                    e.Result = "COMPort已斷線";
                    e.Cancel = true;
                    incomingTags.CompleteAdding();
                    return;
                }

                if (tag == String.Empty) continue;

                incomingTags.Add(tag);
                Debug.WriteLine("Tag Added: " + tag);
            }

            if (worker.CancellationPending)
            {
                incomingTags.CompleteAdding();
                e.Cancel = true;
            }
        }

        private void getTagWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Result != null)
            {
                statusLabel.Text = "已停止接收資料";
            }
        }

        /// <summary>
        /// Consumer，負責將感應到的晶片寫入到欄位中，並回寫到伺服器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void consumer_timer_Tick(object sender, EventArgs e)
        {
            if (incomingTags.IsCompleted)
            {
                consumer_timer.Enabled = false;
            }

            string tag = String.Empty;
            bool result = incomingTags.TryTake(out tag);
            if (result == false || tag == String.Empty) return;

            // 先檢測是否重複
            if (tag == lastTag)
            {
                //statusLabel.Text = "已忽略重複感應的晶片:" + tag;
                return;
            }

            lastTag = tag;

            // 嘗試配對到目前選取的Cell
            var cell = pairDGV.CurrentCell;
            if (cell != null)
            {
                var row_index = cell.RowIndex;
                if (repo.participants[row_index].tag_id == "") // 發現該員沒有配對晶片
                {
                    if (false == repo.helper.tryAddTag(tag))
                    {
                        MessageBox.Show("此晶片已經被配對過，無法再被配對");
                        return;
                    }

                    // 配對成功
                    repo.participants[row_index].tag_id = tag;
                    pairDGV[0, cell.RowIndex].Value = tag;
                    statusLabel.Text = "新增成功";

                    if (repo.participants[row_index].needWriteBack())
                    {
                        statusLabel_API.Text = "儲存變更中";

                        if (false == repo.uploadParticipant(repo.participants[row_index]))
                        {
                           /*
                            * 這邊只限定從無晶片變成有晶片
                            * 所以新增失敗時，移除新晶片就好
                            */
                            repo.helper.cancelTag(tag);
                            statusLabel_API.Text = "儲存變更失敗";
                            repo.participants[row_index].tag_id = "";
                            pairDGV[0, cell.RowIndex].Value = "";
                            return;
                        }
                        else
                        {
                            statusLabel_API.Text = "已儲存所有變更";
                        }
                    }

                    if (cell.RowIndex + 1 < pairDGV.Rows.Count)
                        pairDGV.CurrentCell = pairDGV[0, cell.RowIndex + 1];
                    return;
                }
            }
        }

        /// <summary>
        /// 停止晶片配對
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            stopGetTag();
            start_pair_button.Enabled = true;
            stop_pair_button.Enabled = false;
        }

        private void TagPairingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopGetTag();
        }

        private void stopGetTag()
        {
            getTagWorker.CancelAsync();
            consumer_timer.Enabled = false;
        }
    }
}
