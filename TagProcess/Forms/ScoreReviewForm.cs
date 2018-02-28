using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagProcess.Components;

namespace TagProcess.Forms
{
    public partial class ScoreReviewForm : Form
    {
        private ParticipantsRepository repo = ParticipantsRepository.Instance;
        private TimeKeeper keeper = TimeKeeper.Instance;
        private TagUSBReader usbReader = TagUSBReader.Instance;

        int pid = -1;
        string tag_id = "";
        public ScoreReviewForm()
        {
            InitializeComponent();

            keeper.Log += LogToMe;
        }

        ~ScoreReviewForm()
        {
            keeper.Log -= LogToMe;
        }

        public void LogToMe(string msg)
        {
            MessageBox.Show(msg);
        }

        public void showResult(TimeKeeper.RecordResult res)
        {
            pid = res.id;
            tag_id = res.tag_id;

            textBox_race_id_output.Text = res.race_id;
            textBox_name.Text = res.name;
            textBox_group_type.Text = res.type;
            textBox_group_reg.Text = res.reg;
            textBox_team_name.Text = res.team_name;

            textBox_batch_run_time.Text = res.activity_time.ToString();
            textBox_tag_run_time.Text = res.personal_time.ToString();

            textBox_total_rank.Text = res.total_rank.ToString();
            textBox_team_rank.Text = res.group_rank.ToString();

            textBox_group_count.Text = ActivityCountHelper.getGroupCount(res.group_id).ToString();
            textBox_class_count.Text = ActivityCountHelper.getClassCount(res.group_id).ToString();
        }

        private void button_search_race_Click(object sender, EventArgs e)
        {
            var result = keeper.fetchResultByTagOrRace(null, textBox_race_id.Text);

            if (result == null)
            {
                return;
            }

            showResult(result);
        }

        private void button_search_tag_Click(object sender, EventArgs e)
        {
            string tag = String.Empty;

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
            var result = keeper.fetchResultByTagOrRace(tag, null);
            if (result == null)
            {
                return;
            }

            showResult(result);
        }

        private ScoreArguments getArg()
        {
            ScoreArguments args = new ScoreArguments();

            try
            {
                args.name = textBox_name.Text;
                args.race_id = textBox_race_id_output.Text;
                args.reg = textBox_group_reg.Text;
                args.type = textBox_group_type.Text;
                args.team_name = textBox_team_name.Text;

                args.total_rank = Int32.Parse(textBox_total_rank.Text);
                args.team_rank = Int32.Parse(textBox_team_rank.Text);

                var br_time = TimeSpan.FromSeconds(Int32.Parse(textBox_batch_run_time.Text));
                args.batch_run_time = br_time.ToString(br_time.TotalSeconds >= 3600 ? @"hh' 小時 'mm' 分 'ss' 秒'" : @"mm' 分 'ss' 秒'");
                var tr_time = TimeSpan.FromSeconds(Int32.Parse(textBox_tag_run_time.Text));
                args.tag_run_time = tr_time.ToString(tr_time.TotalSeconds >= 3600 ? @"hh' 小時 'mm' 分 'ss' 秒'" : @"mm' 分 'ss' 秒'");

                args.class_count = Int32.Parse(textBox_class_count.Text);
                args.group_count = Int32.Parse(textBox_group_count.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

            return args;
        }

        private void print_button_Click(object sender, EventArgs e)
        {
            ScoreArguments args = getArg();

            if(args == null || !args.Check())
            {
                return;
            }
        
            ScoreGenerator.SendToPrinter(args, "");
        }

        private void textBox_race_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_search_race_Click(null, null);
        }
    }
}
