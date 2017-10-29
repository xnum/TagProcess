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
using static TagProcess.Components.ScoreGenerator;

namespace TagProcess.Forms
{
    public partial class ScoreListForm : Form
    {
        private ParticipantsRepository repo = ParticipantsRepository.Instance;
        private TimeKeeper keeper = TimeKeeper.Instance;
        private TagUSBReader usbReader = TagUSBReader.Instance;
        public ScoreListForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = "已送印";
            }
        }

        private bool add(TimeKeeper.RecordResult result)
        {
            if (result == null)
                return false;

            dgv.Rows.Insert(0, textBox_race_id.Text, result.p["name"], result.group.name, result.overall.ToString(), result.team.ToString(), "0", result.p["team_name"], "未檢查");

            if (!result.checkData())
            {
                dgv.Rows[0].Cells[7].Value = "異常";
                return false;
            }

            dgv.Rows[0].Cells[7].Value = "正常";

            ScoreArguments args = new ScoreArguments(result);

            dgv.Rows[0].Cells[7].Value = "送印中";

            ScoreGenerator.exportScoreToPDF(args);

            dgv.Rows[0].Cells[7].Value = "已列印";

            return true;
        }

        private void textBox_race_id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return)
                return;
            
            var result = keeper.fetchResultByTagOrRace(null, textBox_race_id.Text);

            /*
            textBox_date.Text = DateTime.Now.ToShortDateString();
            textBox_name.Text = res.p["name"];
            textBox_group.Text = res.group.name;
            textBox_team_name.Text = "";
            textBox_batch_start.Text = res.group.batch_start_time.ToLongTimeString();
            textBox_overall_rank.Text = res.overall.ToString();
            textBox_team_rank.Text = res.team.ToString();
            textBox_team_name.Text = res.p["team_name"];
            */

            if (!add(result)) return;
            
            textBox_race_id.Text = "";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tag = String.Empty;

            if (!usbReader.IsConnected())
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
                textBox_tag_id.Text = "感應逾時";
                return;
            }

            textBox_tag_id.Text = tag;
            var result = keeper.fetchResultByTagOrRace(tag, null);
            if (!add(result))
            {   
                return;
            }

        }
    }
}
