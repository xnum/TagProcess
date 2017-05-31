namespace TagProcess
{
    partial class ReaderForm
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
            this.start_button = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_status0 = new System.Windows.Forms.TextBox();
            this.button_conn0 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_ip0 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_time0 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_status1 = new System.Windows.Forms.TextBox();
            this.button_conn1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_ip1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_time1 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_status2 = new System.Windows.Forms.TextBox();
            this.button_conn2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_ip2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_time2 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // start_button
            // 
            this.start_button.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.start_button.Location = new System.Drawing.Point(6, 298);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(121, 48);
            this.start_button.TabIndex = 0;
            this.start_button.Text = "開始";
            this.start_button.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "起點",
            "1",
            "2",
            "3",
            "終點"});
            this.comboBox1.Location = new System.Drawing.Point(8, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "檢查點編號";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "男甲組",
            "男乙組",
            "男丙組",
            "男丁組",
            "女甲組",
            "女乙組",
            "女丙組",
            "女丁組"});
            this.checkedListBox1.Location = new System.Drawing.Point(8, 120);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 174);
            this.checkedListBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "起跑批次";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox2.Location = new System.Drawing.Point(8, 77);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 20);
            this.comboBox2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "起跑組別";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.start_button);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 353);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "檢查點設定";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_status0);
            this.groupBox2.Controls.Add(this.button_conn0);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox_ip0);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_time0);
            this.groupBox2.Location = new System.Drawing.Point(160, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(213, 100);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reader 1";
            // 
            // textBox_status0
            // 
            this.textBox_status0.Location = new System.Drawing.Point(7, 69);
            this.textBox_status0.Name = "textBox_status0";
            this.textBox_status0.ReadOnly = true;
            this.textBox_status0.Size = new System.Drawing.Size(112, 22);
            this.textBox_status0.TabIndex = 16;
            this.textBox_status0.Text = "未設定";
            // 
            // button_conn0
            // 
            this.button_conn0.Location = new System.Drawing.Point(125, 69);
            this.button_conn0.Name = "button_conn0";
            this.button_conn0.Size = new System.Drawing.Size(75, 23);
            this.button_conn0.TabIndex = 15;
            this.button_conn0.Tag = "0";
            this.button_conn0.Text = "連接";
            this.button_conn0.UseVisualStyleBackColor = true;
            this.button_conn0.Click += new System.EventHandler(this.button_conn0_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "機器IP";
            // 
            // textBox_ip0
            // 
            this.textBox_ip0.Location = new System.Drawing.Point(66, 17);
            this.textBox_ip0.Name = "textBox_ip0";
            this.textBox_ip0.Size = new System.Drawing.Size(140, 22);
            this.textBox_ip0.TabIndex = 13;
            this.textBox_ip0.Tag = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "機器時間";
            // 
            // textBox_time0
            // 
            this.textBox_time0.Location = new System.Drawing.Point(66, 42);
            this.textBox_time0.Name = "textBox_time0";
            this.textBox_time0.ReadOnly = true;
            this.textBox_time0.Size = new System.Drawing.Size(140, 22);
            this.textBox_time0.TabIndex = 11;
            this.textBox_time0.Tag = "0";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(226, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(140, 22);
            this.textBox1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "電腦時間";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_status1);
            this.groupBox3.Controls.Add(this.button_conn1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBox_ip1);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.textBox_time1);
            this.groupBox3.Location = new System.Drawing.Point(160, 155);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(213, 100);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Reader 2";
            // 
            // textBox_status1
            // 
            this.textBox_status1.Location = new System.Drawing.Point(7, 69);
            this.textBox_status1.Name = "textBox_status1";
            this.textBox_status1.ReadOnly = true;
            this.textBox_status1.Size = new System.Drawing.Size(112, 22);
            this.textBox_status1.TabIndex = 16;
            this.textBox_status1.Text = "未設定";
            // 
            // button_conn1
            // 
            this.button_conn1.Location = new System.Drawing.Point(125, 69);
            this.button_conn1.Name = "button_conn1";
            this.button_conn1.Size = new System.Drawing.Size(75, 23);
            this.button_conn1.TabIndex = 15;
            this.button_conn1.Tag = "1";
            this.button_conn1.Text = "連接";
            this.button_conn1.UseVisualStyleBackColor = true;
            this.button_conn1.Click += new System.EventHandler(this.button_conn0_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "機器IP";
            // 
            // textBox_ip1
            // 
            this.textBox_ip1.Location = new System.Drawing.Point(66, 17);
            this.textBox_ip1.Name = "textBox_ip1";
            this.textBox_ip1.Size = new System.Drawing.Size(140, 22);
            this.textBox_ip1.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 12;
            this.label8.Text = "機器時間";
            // 
            // textBox_time1
            // 
            this.textBox_time1.Location = new System.Drawing.Point(66, 42);
            this.textBox_time1.Name = "textBox_time1";
            this.textBox_time1.ReadOnly = true;
            this.textBox_time1.Size = new System.Drawing.Size(140, 22);
            this.textBox_time1.TabIndex = 11;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_status2);
            this.groupBox4.Controls.Add(this.button_conn2);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.textBox_ip2);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.textBox_time2);
            this.groupBox4.Location = new System.Drawing.Point(160, 261);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(213, 100);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Reader 3";
            // 
            // textBox_status2
            // 
            this.textBox_status2.Location = new System.Drawing.Point(7, 69);
            this.textBox_status2.Name = "textBox_status2";
            this.textBox_status2.ReadOnly = true;
            this.textBox_status2.Size = new System.Drawing.Size(112, 22);
            this.textBox_status2.TabIndex = 16;
            this.textBox_status2.Text = "未設定";
            // 
            // button_conn2
            // 
            this.button_conn2.Location = new System.Drawing.Point(125, 69);
            this.button_conn2.Name = "button_conn2";
            this.button_conn2.Size = new System.Drawing.Size(75, 23);
            this.button_conn2.TabIndex = 15;
            this.button_conn2.Tag = "2";
            this.button_conn2.Text = "連接";
            this.button_conn2.UseVisualStyleBackColor = true;
            this.button_conn2.Click += new System.EventHandler(this.button_conn0_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "機器IP";
            // 
            // textBox_ip2
            // 
            this.textBox_ip2.Location = new System.Drawing.Point(66, 17);
            this.textBox_ip2.Name = "textBox_ip2";
            this.textBox_ip2.Size = new System.Drawing.Size(140, 22);
            this.textBox_ip2.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "機器時間";
            // 
            // textBox_time2
            // 
            this.textBox_time2.Location = new System.Drawing.Point(66, 42);
            this.textBox_time2.Name = "textBox_time2";
            this.textBox_time2.ReadOnly = true;
            this.textBox_time2.Size = new System.Drawing.Size(140, 22);
            this.textBox_time2.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(385, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(421, 349);
            this.dataGridView1.TabIndex = 19;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "編號";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 70;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "姓名";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 70;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "組別";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "感應時間";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // ReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 376);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReaderForm";
            this.Text = "ReaderForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_status0;
        private System.Windows.Forms.Button button_conn0;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_ip0;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_time0;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_status1;
        private System.Windows.Forms.Button button_conn1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_ip1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_time1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox_status2;
        private System.Windows.Forms.Button button_conn2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_ip2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_time2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}