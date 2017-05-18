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

            retParticipant = current;

            textBox_id.Text = retParticipant.id.ToString();
            textBox_name.Text = retParticipant.name;
            textBox_phone.Text = retParticipant.phone;
            textBox_tag_id.Text = retParticipant.tag_id;
            textBox_race_id.Text = retParticipant.race_id;
            textBox_birth.Text = retParticipant.birth;
            textBox_addr.Text = retParticipant.address;
            textBox_zipcode.Text = retParticipant.zipcode;
            textBox_age.Text = retParticipant.age.ToString();
            comboBox_male.Text = retParticipant.male_s;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
