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
    public partial class ParticipantsEditForm : Form
    {
        public Participant retParticipant;
        string currentReceivedTag = String.Empty;

        public ParticipantsEditForm(Participant current)
        {
            InitializeComponent();
            comboBox_groups.Items.Clear();
            comboBox_groups.Items.AddRange(ParticipantsRepository.Instance.helper.getGroupNames().ToArray());
            retParticipant = current;

            textBox_id.Text = retParticipant.id.ToString();
            textBox_name.Text = retParticipant.name;
            textBox_phone.Text = retParticipant.phone;
            textBox_tag_id.Text = retParticipant.tag_id;
            textBox_race_id.Text = retParticipant.race_id;
            textBox_birth.Text = retParticipant.birth;
            textBox_addr.Text = retParticipant.address;
            textBox_zipcode.Text = retParticipant.zipcode;
            textBox_age.Text = retParticipant.age;

            comboBox_male.Text = retParticipant.male_s;
            comboBox_groups.Text = retParticipant.group;
        }

        /// <summary>
        /// 儲存並關閉視窗
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ok_Click(object sender, EventArgs e)
        {
            if (textBox_name.Text != retParticipant.name)
                retParticipant.name = textBox_name.Text;

            if (textBox_phone.Text != retParticipant.phone)
                retParticipant.phone = textBox_phone.Text;

            if (textBox_tag_id.Text != retParticipant.tag_id)
                retParticipant.tag_id = textBox_tag_id.Text;

            if (textBox_birth.Text != retParticipant.birth)
                retParticipant.birth = textBox_birth.Text;

            if (textBox_addr.Text != retParticipant.address)
                retParticipant.address = textBox_addr.Text;

            if (textBox_zipcode.Text != retParticipant.zipcode)
                retParticipant.zipcode = textBox_zipcode.Text;

            if (comboBox_male.Text != retParticipant.male_s)
                retParticipant.male_s = comboBox_male.Text;

            if (comboBox_groups.Text != retParticipant.group)
                retParticipant.group = comboBox_groups.Text;

            this.Close();
        }

        /// <summary>
        /// 變更晶片按紐，呼叫Worker等候接收資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeTagID_Click(object sender, EventArgs e)
        {
            currentReceivedTag = String.Empty;
            if (changeTagID.Text == "晶片變更")
            {
                statusLabel.Text = "等候晶片感應中";
                if (!getTagWorker.IsBusy)
                {
                    getTagWorker.RunWorkerAsync();
                    changeTagID.Text = "取消感應";
                }
            } 
            else
            {
                if (getTagWorker.IsBusy)
                {
                    statusLabel.Text = "取消感應中";
                    getTagWorker.CancelAsync();
                }
            }
        }

        private void getTagWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)sender;
            while (!worker.CancellationPending)
            {
                string result = String.Empty;
                try
                {
                    result = TagUSBReader.Instance.ReadTag(); // blocking up to 500ms
                }
                catch (InvalidOperationException)
                {
                    worker.CancelAsync();
                    e.Result = "COMPort已斷線";
                    break;
                }

                // 收到晶片ID後立即結束工作
                if (result != String.Empty)
                {
                    currentReceivedTag = result;
                    return;
                }
            }

            e.Cancel = true;
        }

        private void getTagWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            changeTagID.Text = "晶片變更";

            if (e.Cancelled)
            {
                statusLabel.Text = "";
                
                return;
            }

            if (currentReceivedTag == String.Empty) return;
            
            if (true == ParticipantsRepository.Instance.helper.isExistsTag(currentReceivedTag))
            {
                statusLabel.Text = "這個晶片已經被其他選手使用";
            }
            else
            {
                statusLabel.Text = "變更完成";
                retParticipant.tag_id = currentReceivedTag;
                textBox_tag_id.Text = currentReceivedTag;
            }
        }

        private void ParticipantsEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            getTagWorker.CancelAsync();
        }
    }
}
