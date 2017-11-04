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
        public ScoreReviewForm()
        {
            InitializeComponent();
        }

        public void showResult(TimeKeeper.RecordResult res)
        {
            textBox_date.Text = DateTime.Now.ToShortDateString();
            textBox_name.Text = res.p["name"];
            textBox_group.Text = res.group.name;
            textBox_team_name.Text = "";
            textBox_batch_start.Text = res.group.batch_start_time.ToLongTimeString();
            textBox_overall_rank.Text = res.overall.ToString();
            textBox_team_rank.Text = res.team.ToString();
            textBox_team_name.Text = res.p["team_name"];
            foreach (var r in res.recs)
            {
                switch(r.station_id)
                {
                    case "1":
                        textBox_tag_start.Text = r.time.ToLongTimeString();
                        break;
                    case "2":
                        textBox_check1.Text = r.time.ToLongTimeString();
                        break;
                    case "3":
                        textBox_check2.Text = r.time.ToLongTimeString();
                        break;
                    case "4":
                        textBox_check3.Text = r.time.ToLongTimeString();
                        break;
                    default:
                        textBox_tag_end.Text = r.time.ToLongTimeString();
                        break;
                }
                
            }

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

        private void print_button_Click(object sender, EventArgs e)
        {
            ScoreArguments args = new ScoreArguments();

            args.today = textBox_date.Text;
            args.name = textBox_name.Text;
            args.group = textBox_group.Text;
            args.team_name = textBox_team_name.Text;
            args.overall_rank = textBox_overall_rank.Text;
            args.team_rank = textBox_team_rank.Text;
            args.tag_end_time = DateTime.Parse(textBox_tag_end.Text);
            args.tag_start_time = DateTime.Parse(textBox_tag_start.Text);
            args.batch_start_time = DateTime.Parse(textBox_batch_start.Text);

            if(!args.Check())
            {
                return;
            }

            args.CountRunTime();
            // TODO write back to db
            ScoreGenerator sg = new ScoreGenerator();
            sg.exportScoreToPDF(args, "");
            //ScoreGenerator.exportScoreToPDF(args);
        }

        private void textBox_race_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button_search_race_Click(null, null);
        }
    }
}
