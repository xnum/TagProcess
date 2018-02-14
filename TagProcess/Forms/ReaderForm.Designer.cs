namespace TagProcess
{
    partial class ReaderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.touchedView = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refresh_timer = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label_localtime = new System.Windows.Forms.Label();
            this.label_reader1 = new System.Windows.Forms.Label();
            this.textBox_reader_ip1 = new System.Windows.Forms.TextBox();
            this.button_reader_conn1 = new System.Windows.Forms.Button();
            this.button_reader_conn2 = new System.Windows.Forms.Button();
            this.textBox_reader_ip2 = new System.Windows.Forms.TextBox();
            this.label_reader2 = new System.Windows.Forms.Label();
            this.button_reader_conn3 = new System.Windows.Forms.Button();
            this.textBox_reader_ip3 = new System.Windows.Forms.TextBox();
            this.label_reader3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_buffered = new System.Windows.Forms.Label();
            this.label_upload = new System.Windows.Forms.Label();
            this.label_total = new System.Windows.Forms.Label();
            this.label_tagged = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgv_group = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox_station = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.touchedView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_group)).BeginInit();
            this.SuspendLayout();
            // 
            // touchedView
            // 
            this.touchedView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.touchedView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6});
            this.touchedView.Location = new System.Drawing.Point(532, 12);
            this.touchedView.Name = "touchedView";
            this.touchedView.RowHeadersVisible = false;
            this.touchedView.RowTemplate.Height = 24;
            this.touchedView.Size = new System.Drawing.Size(687, 470);
            this.touchedView.TabIndex = 19;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.FillWeight = 150F;
            this.Column5.HeaderText = "晶片tag";
            this.Column5.MinimumWidth = 130;
            this.Column5.Name = "Column5";
            this.Column5.Width = 130;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.FillWeight = 120F;
            this.Column1.HeaderText = "編號";
            this.Column1.MinimumWidth = 100;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "姓名";
            this.Column2.MinimumWidth = 80;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "組別";
            this.Column3.MinimumWidth = 100;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "感應時間";
            this.Column4.MinimumWidth = 100;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "起點時間";
            this.Column6.MinimumWidth = 100;
            this.Column6.Name = "Column6";
            // 
            // refresh_timer
            // 
            this.refresh_timer.Enabled = true;
            this.refresh_timer.Tick += new System.EventHandler(this.refresh_timer_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "電腦時間";
            // 
            // label_localtime
            // 
            this.label_localtime.AutoSize = true;
            this.label_localtime.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_localtime.Location = new System.Drawing.Point(72, 17);
            this.label_localtime.Name = "label_localtime";
            this.label_localtime.Size = new System.Drawing.Size(53, 19);
            this.label_localtime.TabIndex = 20;
            this.label_localtime.Text = "label1";
            // 
            // label_reader1
            // 
            this.label_reader1.AutoSize = true;
            this.label_reader1.Location = new System.Drawing.Point(14, 56);
            this.label_reader1.Name = "label_reader1";
            this.label_reader1.Size = new System.Drawing.Size(44, 12);
            this.label_reader1.TabIndex = 21;
            this.label_reader1.Text = "Reader1";
            // 
            // textBox_reader_ip1
            // 
            this.textBox_reader_ip1.Location = new System.Drawing.Point(64, 50);
            this.textBox_reader_ip1.Name = "textBox_reader_ip1";
            this.textBox_reader_ip1.Size = new System.Drawing.Size(100, 22);
            this.textBox_reader_ip1.TabIndex = 22;
            // 
            // button_reader_conn1
            // 
            this.button_reader_conn1.Location = new System.Drawing.Point(170, 50);
            this.button_reader_conn1.Name = "button_reader_conn1";
            this.button_reader_conn1.Size = new System.Drawing.Size(75, 23);
            this.button_reader_conn1.TabIndex = 23;
            this.button_reader_conn1.Tag = "0";
            this.button_reader_conn1.Text = "連線";
            this.button_reader_conn1.UseVisualStyleBackColor = true;
            this.button_reader_conn1.Click += new System.EventHandler(this.button_conn0_Click);
            // 
            // button_reader_conn2
            // 
            this.button_reader_conn2.Location = new System.Drawing.Point(170, 78);
            this.button_reader_conn2.Name = "button_reader_conn2";
            this.button_reader_conn2.Size = new System.Drawing.Size(75, 23);
            this.button_reader_conn2.TabIndex = 26;
            this.button_reader_conn2.Tag = "1";
            this.button_reader_conn2.Text = "連線";
            this.button_reader_conn2.UseVisualStyleBackColor = true;
            this.button_reader_conn2.Click += new System.EventHandler(this.button_conn0_Click);
            // 
            // textBox_reader_ip2
            // 
            this.textBox_reader_ip2.Location = new System.Drawing.Point(64, 78);
            this.textBox_reader_ip2.Name = "textBox_reader_ip2";
            this.textBox_reader_ip2.Size = new System.Drawing.Size(100, 22);
            this.textBox_reader_ip2.TabIndex = 25;
            // 
            // label_reader2
            // 
            this.label_reader2.AutoSize = true;
            this.label_reader2.Location = new System.Drawing.Point(14, 84);
            this.label_reader2.Name = "label_reader2";
            this.label_reader2.Size = new System.Drawing.Size(44, 12);
            this.label_reader2.TabIndex = 24;
            this.label_reader2.Text = "Reader2";
            // 
            // button_reader_conn3
            // 
            this.button_reader_conn3.Location = new System.Drawing.Point(170, 106);
            this.button_reader_conn3.Name = "button_reader_conn3";
            this.button_reader_conn3.Size = new System.Drawing.Size(75, 23);
            this.button_reader_conn3.TabIndex = 29;
            this.button_reader_conn3.Tag = "2";
            this.button_reader_conn3.Text = "連線";
            this.button_reader_conn3.UseVisualStyleBackColor = true;
            this.button_reader_conn3.Click += new System.EventHandler(this.button_conn0_Click);
            // 
            // textBox_reader_ip3
            // 
            this.textBox_reader_ip3.Location = new System.Drawing.Point(64, 106);
            this.textBox_reader_ip3.Name = "textBox_reader_ip3";
            this.textBox_reader_ip3.Size = new System.Drawing.Size(100, 22);
            this.textBox_reader_ip3.TabIndex = 28;
            // 
            // label_reader3
            // 
            this.label_reader3.AutoSize = true;
            this.label_reader3.Location = new System.Drawing.Point(14, 112);
            this.label_reader3.Name = "label_reader3";
            this.label_reader3.Size = new System.Drawing.Size(44, 12);
            this.label_reader3.TabIndex = 27;
            this.label_reader3.Text = "Reader3";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_buffered);
            this.groupBox1.Controls.Add(this.label_upload);
            this.groupBox1.Controls.Add(this.label_total);
            this.groupBox1.Controls.Add(this.label_tagged);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 352);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 130);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "人數資訊";
            // 
            // label_buffered
            // 
            this.label_buffered.AutoSize = true;
            this.label_buffered.Location = new System.Drawing.Point(92, 98);
            this.label_buffered.Name = "label_buffered";
            this.label_buffered.Size = new System.Drawing.Size(11, 12);
            this.label_buffered.TabIndex = 7;
            this.label_buffered.Text = "0";
            // 
            // label_upload
            // 
            this.label_upload.AutoSize = true;
            this.label_upload.Location = new System.Drawing.Point(92, 72);
            this.label_upload.Name = "label_upload";
            this.label_upload.Size = new System.Drawing.Size(11, 12);
            this.label_upload.TabIndex = 6;
            this.label_upload.Text = "0";
            // 
            // label_total
            // 
            this.label_total.AutoSize = true;
            this.label_total.Location = new System.Drawing.Point(92, 46);
            this.label_total.Name = "label_total";
            this.label_total.Size = new System.Drawing.Size(11, 12);
            this.label_total.TabIndex = 5;
            this.label_total.Text = "0";
            // 
            // label_tagged
            // 
            this.label_tagged.AutoSize = true;
            this.label_tagged.Location = new System.Drawing.Point(92, 21);
            this.label_tagged.Name = "label_tagged";
            this.label_tagged.Size = new System.Drawing.Size(11, 12);
            this.label_tagged.TabIndex = 4;
            this.label_tagged.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "待上傳人數：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "活動人數：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "已上傳人數：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "已感應人數：";
            // 
            // textBox_log
            // 
            this.textBox_log.Location = new System.Drawing.Point(210, 352);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_log.Size = new System.Drawing.Size(307, 130);
            this.textBox_log.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 32;
            this.label6.Text = "異常狀況";
            // 
            // dgv_group
            // 
            this.dgv_group.AllowUserToAddRows = false;
            this.dgv_group.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_group.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column10,
            this.Column8,
            this.Column9});
            this.dgv_group.Location = new System.Drawing.Point(14, 152);
            this.dgv_group.Name = "dgv_group";
            this.dgv_group.RowHeadersVisible = false;
            this.dgv_group.RowTemplate.Height = 24;
            this.dgv_group.Size = new System.Drawing.Size(404, 159);
            this.dgv_group.TabIndex = 33;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 20F;
            this.Column7.HeaderText = "";
            this.Column7.Name = "Column7";
            this.Column7.Width = 20;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "ID";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 40;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "組別名稱";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 150;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "起跑時間";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 140;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(433, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "紀錄鳴槍";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_station
            // 
            this.comboBox_station.FormattingEnabled = true;
            this.comboBox_station.Items.AddRange(new object[] {
            "起點",
            "檢查點1",
            "檢查點2",
            "檢查點3",
            "終點"});
            this.comboBox_station.Location = new System.Drawing.Point(387, 48);
            this.comboBox_station.Name = "comboBox_station";
            this.comboBox_station.Size = new System.Drawing.Size(121, 20);
            this.comboBox_station.TabIndex = 35;
            this.comboBox_station.SelectedIndexChanged += new System.EventHandler(this.comboBox_station_SelectedIndexChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(433, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 36;
            this.button2.Tag = "0";
            this.button2.Text = "定時工作";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 505);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox_station);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv_group);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_log);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_reader_conn3);
            this.Controls.Add(this.textBox_reader_ip3);
            this.Controls.Add(this.label_reader3);
            this.Controls.Add(this.button_reader_conn2);
            this.Controls.Add(this.textBox_reader_ip2);
            this.Controls.Add(this.label_reader2);
            this.Controls.Add(this.button_reader_conn1);
            this.Controls.Add(this.textBox_reader_ip1);
            this.Controls.Add(this.label_reader1);
            this.Controls.Add(this.label_localtime);
            this.Controls.Add(this.touchedView);
            this.Controls.Add(this.label4);
            this.Name = "ReaderForm";
            this.Text = "ReaderForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReaderForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.touchedView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_group)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView touchedView;
        private System.Windows.Forms.Timer refresh_timer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_localtime;
        private System.Windows.Forms.Label label_reader1;
        private System.Windows.Forms.TextBox textBox_reader_ip1;
        private System.Windows.Forms.Button button_reader_conn1;
        private System.Windows.Forms.Button button_reader_conn2;
        private System.Windows.Forms.TextBox textBox_reader_ip2;
        private System.Windows.Forms.Label label_reader2;
        private System.Windows.Forms.Button button_reader_conn3;
        private System.Windows.Forms.TextBox textBox_reader_ip3;
        private System.Windows.Forms.Label label_reader3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_log;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgv_group;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.ComboBox comboBox_station;
        private System.Windows.Forms.Label label_buffered;
        private System.Windows.Forms.Label label_upload;
        private System.Windows.Forms.Label label_total;
        private System.Windows.Forms.Label label_tagged;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button2;
    }
}