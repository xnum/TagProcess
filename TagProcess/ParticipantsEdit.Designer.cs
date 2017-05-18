namespace TagProcess
{
    partial class ParticipantsEdit
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_phone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_addr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_zipcode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_age = new System.Windows.Forms.TextBox();
            this.textBox_race_id = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_birth = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "晶片號碼";
            // 
            // textBox_tag_id
            // 
            this.textBox_tag_id.Location = new System.Drawing.Point(26, 38);
            this.textBox_tag_id.Name = "textBox_tag_id";
            this.textBox_tag_id.ReadOnly = true;
            this.textBox_tag_id.Size = new System.Drawing.Size(100, 22);
            this.textBox_tag_id.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(132, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "晶片變更";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_birth);
            this.groupBox1.Controls.Add(this.textBox_id);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBox_age);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBox_zipcode);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_addr);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_phone);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_name);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(26, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 190);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "選手資料";
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
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(15, 38);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(100, 22);
            this.textBox_name.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "性別";
            // 
            // textBox_phone
            // 
            this.textBox_phone.Location = new System.Drawing.Point(15, 152);
            this.textBox_phone.Name = "textBox_phone";
            this.textBox_phone.Size = new System.Drawing.Size(100, 22);
            this.textBox_phone.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "電話";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "男",
            "女"});
            this.comboBox1.Location = new System.Drawing.Point(15, 97);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 20);
            this.comboBox1.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(233, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "地址";
            // 
            // textBox_addr
            // 
            this.textBox_addr.Location = new System.Drawing.Point(235, 38);
            this.textBox_addr.Name = "textBox_addr";
            this.textBox_addr.Size = new System.Drawing.Size(210, 22);
            this.textBox_addr.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(129, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "郵遞區號";
            // 
            // textBox_zipcode
            // 
            this.textBox_zipcode.Location = new System.Drawing.Point(129, 38);
            this.textBox_zipcode.Name = "textBox_zipcode";
            this.textBox_zipcode.Size = new System.Drawing.Size(100, 22);
            this.textBox_zipcode.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(129, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "生日";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(235, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "年齡";
            // 
            // textBox_age
            // 
            this.textBox_age.Location = new System.Drawing.Point(237, 97);
            this.textBox_age.Name = "textBox_age";
            this.textBox_age.ReadOnly = true;
            this.textBox_age.Size = new System.Drawing.Size(100, 22);
            this.textBox_age.TabIndex = 13;
            // 
            // textBox_race_id
            // 
            this.textBox_race_id.Location = new System.Drawing.Point(223, 38);
            this.textBox_race_id.Name = "textBox_race_id";
            this.textBox_race_id.Size = new System.Drawing.Size(100, 22);
            this.textBox_race_id.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(221, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "號碼布號碼";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(127, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "編號";
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(129, 152);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.ReadOnly = true;
            this.textBox_id.Size = new System.Drawing.Size(100, 22);
            this.textBox_id.TabIndex = 15;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(356, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 40);
            this.button2.TabIndex = 6;
            this.button2.Text = "儲存變更";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox_birth
            // 
            this.textBox_birth.Location = new System.Drawing.Point(129, 97);
            this.textBox_birth.Name = "textBox_birth";
            this.textBox_birth.Size = new System.Drawing.Size(100, 22);
            this.textBox_birth.TabIndex = 16;
            // 
            // ParticipantsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 288);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox_race_id);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_tag_id);
            this.Controls.Add(this.label1);
            this.Name = "ParticipantsEdit";
            this.Text = "參賽選手編輯";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_tag_id;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_age;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_zipcode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_addr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_phone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_race_id;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox_birth;
    }
}