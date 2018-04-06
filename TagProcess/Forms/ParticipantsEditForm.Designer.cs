namespace TagProcess
{
    partial class ParticipantsEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_tag_id = new System.Windows.Forms.TextBox();
            this.changeTagID = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox_groups = new System.Windows.Forms.ComboBox();
            this.textBox_birth = new System.Windows.Forms.TextBox();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_age = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_team_name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_addr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_male = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_phone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_race_id = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button_ok = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.getTagWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "晶片號碼";
            // 
            // textBox_tag_id
            // 
            this.textBox_tag_id.Location = new System.Drawing.Point(26, 73);
            this.textBox_tag_id.Name = "textBox_tag_id";
            this.textBox_tag_id.ReadOnly = true;
            this.textBox_tag_id.Size = new System.Drawing.Size(116, 22);
            this.textBox_tag_id.TabIndex = 1;
            // 
            // changeTagID
            // 
            this.changeTagID.Location = new System.Drawing.Point(148, 72);
            this.changeTagID.Name = "changeTagID";
            this.changeTagID.Size = new System.Drawing.Size(75, 23);
            this.changeTagID.TabIndex = 2;
            this.changeTagID.Text = "晶片變更";
            this.changeTagID.UseVisualStyleBackColor = true;
            this.changeTagID.Click += new System.EventHandler(this.changeTagID_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.comboBox_groups);
            this.groupBox1.Controls.Add(this.textBox_birth);
            this.groupBox1.Controls.Add(this.textBox_id);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBox_age);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_team_name);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_addr);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBox_male);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_phone);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(26, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 133);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "選手資料";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(316, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "比賽組別";
            // 
            // comboBox_groups
            // 
            this.comboBox_groups.FormattingEnabled = true;
            this.comboBox_groups.Items.AddRange(new object[] {
            "男1",
            "男2"});
            this.comboBox_groups.Location = new System.Drawing.Point(318, 95);
            this.comboBox_groups.Name = "comboBox_groups";
            this.comboBox_groups.Size = new System.Drawing.Size(86, 20);
            this.comboBox_groups.TabIndex = 17;
            // 
            // textBox_birth
            // 
            this.textBox_birth.Location = new System.Drawing.Point(87, 95);
            this.textBox_birth.Name = "textBox_birth";
            this.textBox_birth.Size = new System.Drawing.Size(85, 22);
            this.textBox_birth.TabIndex = 16;
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(410, 95);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.ReadOnly = true;
            this.textBox_id.Size = new System.Drawing.Size(39, 22);
            this.textBox_id.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(408, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "編號";
            // 
            // textBox_age
            // 
            this.textBox_age.Location = new System.Drawing.Point(178, 95);
            this.textBox_age.Name = "textBox_age";
            this.textBox_age.ReadOnly = true;
            this.textBox_age.Size = new System.Drawing.Size(27, 22);
            this.textBox_age.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(176, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "年齡";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(87, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "生日";
            // 
            // textBox_team_name
            // 
            this.textBox_team_name.Location = new System.Drawing.Point(126, 38);
            this.textBox_team_name.Name = "textBox_team_name";
            this.textBox_team_name.Size = new System.Drawing.Size(76, 22);
            this.textBox_team_name.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(127, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "報名團體";
            // 
            // textBox_addr
            // 
            this.textBox_addr.Location = new System.Drawing.Point(212, 38);
            this.textBox_addr.Name = "textBox_addr";
            this.textBox_addr.Size = new System.Drawing.Size(210, 22);
            this.textBox_addr.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "地址";
            // 
            // comboBox_male
            // 
            this.comboBox_male.FormattingEnabled = true;
            this.comboBox_male.Items.AddRange(new object[] {
            "男",
            "女"});
            this.comboBox_male.Location = new System.Drawing.Point(15, 95);
            this.comboBox_male.Name = "comboBox_male";
            this.comboBox_male.Size = new System.Drawing.Size(66, 20);
            this.comboBox_male.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "電話";
            // 
            // textBox_phone
            // 
            this.textBox_phone.Location = new System.Drawing.Point(211, 95);
            this.textBox_phone.Name = "textBox_phone";
            this.textBox_phone.Size = new System.Drawing.Size(100, 22);
            this.textBox_phone.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "性別";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(15, 38);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(100, 22);
            this.textBox_name.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "姓名";
            // 
            // textBox_race_id
            // 
            this.textBox_race_id.Location = new System.Drawing.Point(291, 73);
            this.textBox_race_id.Name = "textBox_race_id";
            this.textBox_race_id.ReadOnly = true;
            this.textBox_race_id.Size = new System.Drawing.Size(63, 22);
            this.textBox_race_id.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(289, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "號碼布號碼";
            // 
            // button_ok
            // 
            this.button_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_ok.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_ok.Location = new System.Drawing.Point(364, 60);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(115, 40);
            this.button_ok.TabIndex = 6;
            this.button_ok.Text = "儲存變更";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(20, 261);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(466, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // getTagWorker
            // 
            this.getTagWorker.WorkerSupportsCancellation = true;
            this.getTagWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.getTagWorker_DoWork);
            this.getTagWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.getTagWorker_RunWorkerCompleted);
            // 
            // ParticipantsEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 303);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_ok);
            this.Controls.Add(this.textBox_race_id);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.changeTagID);
            this.Controls.Add(this.textBox_tag_id);
            this.Controls.Add(this.label1);
            this.Name = "ParticipantsEditForm";
            this.Resizable = false;
            this.Text = "參賽選手編輯";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ParticipantsEdit_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_tag_id;
        private System.Windows.Forms.Button changeTagID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_age;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_team_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_addr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_male;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_phone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_race_id;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.TextBox textBox_birth;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox_groups;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.ComponentModel.BackgroundWorker getTagWorker;
    }
}