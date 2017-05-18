using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TagProcess
{
    public partial class ParticipantsEdit : Form
    {
        public Participant retParticipant;
        public ParticipantsEdit(Participant current)
        {
            InitializeComponent();
            comboBox_groups.Items.Clear();
            comboBox_groups.Items.AddRange(ParticipantHelper.getGroupNames().ToArray());
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
             
            this.Close();
        }

        private void changeTagID_Click(object sender, EventArgs e)
        {
            // TODO scan form
            string tag = "AAA";
            if (false == ParticipantHelper.tryAddTag(tag))
            {
                MessageBox.Show("這個晶片已經被其他選手使用");
            }
            else
            {
                retParticipant.tag_id = tag;
                textBox_tag_id.Text = tag;
            }
        }
    }
}
