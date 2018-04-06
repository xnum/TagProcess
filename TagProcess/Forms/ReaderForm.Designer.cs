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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.touchedView = new MetroFramework.Controls.MetroGrid();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refresh_timer = new System.Windows.Forms.Timer(this.components);
            this.label_localtime = new System.Windows.Forms.Label();
            this.label_reader1 = new System.Windows.Forms.Label();
            this.textBox_reader_ip1 = new MetroFramework.Controls.MetroTextBox();
            this.button_reader_conn1 = new System.Windows.Forms.Button();
            this.button_reader_conn2 = new System.Windows.Forms.Button();
            this.textBox_reader_ip2 = new MetroFramework.Controls.MetroTextBox();
            this.label_reader2 = new System.Windows.Forms.Label();
            this.button_reader_conn3 = new System.Windows.Forms.Button();
            this.textBox_reader_ip3 = new MetroFramework.Controls.MetroTextBox();
            this.label_reader3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_dup = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_buffered = new System.Windows.Forms.Label();
            this.label_upload = new System.Windows.Forms.Label();
            this.label_total = new System.Windows.Forms.Label();
            this.label_tagged = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_log = new MetroFramework.Controls.MetroTextBox();
            this.dgv_group = new MetroFramework.Controls.MetroGrid();
            this.Column7 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox_station = new System.Windows.Forms.ComboBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.checkBox_station = new System.Windows.Forms.CheckBox();
            this.textBox_station = new MetroFramework.Controls.MetroGrid();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.button2 = new MetroFramework.Controls.MetroButton();
            this.metroButton3 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            ((System.ComponentModel.ISupportInitialize)(this.touchedView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_group)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_station)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // touchedView
            // 
            this.touchedView.AllowUserToResizeRows = false;
            this.touchedView.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.touchedView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.touchedView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.touchedView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.touchedView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.touchedView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.touchedView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.touchedView.DefaultCellStyle = dataGridViewCellStyle2;
            this.touchedView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.touchedView.EnableHeadersVisualStyles = false;
            this.touchedView.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.touchedView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.touchedView.Location = new System.Drawing.Point(528, 3);
            this.touchedView.Name = "touchedView";
            this.touchedView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.touchedView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.touchedView.RowHeadersVisible = false;
            this.touchedView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tableLayoutPanel1.SetRowSpan(this.touchedView, 3);
            this.touchedView.RowTemplate.Height = 24;
            this.touchedView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.touchedView.Size = new System.Drawing.Size(660, 496);
            this.touchedView.TabIndex = 19;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.FillWeight = 150F;
            this.Column5.HeaderText = "晶片tag";
            this.Column5.MinimumWidth = 130;
            this.Column5.Name = "Column5";
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.FillWeight = 120F;
            this.Column1.HeaderText = "編號";
            this.Column1.MinimumWidth = 100;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "姓名";
            this.Column2.MinimumWidth = 80;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "組別";
            this.Column3.MinimumWidth = 100;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "感應時間";
            this.Column4.MinimumWidth = 100;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "起點時間";
            this.Column6.MinimumWidth = 100;
            this.Column6.Name = "Column6";
            // 
            // refresh_timer
            // 
            this.refresh_timer.Enabled = true;
            this.refresh_timer.Tick += new System.EventHandler(this.refresh_timer_Tick);
            // 
            // label_localtime
            // 
            this.label_localtime.AutoSize = true;
            this.label_localtime.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_localtime.Location = new System.Drawing.Point(188, 27);
            this.label_localtime.Name = "label_localtime";
            this.label_localtime.Size = new System.Drawing.Size(53, 19);
            this.label_localtime.TabIndex = 20;
            this.label_localtime.Text = "label1";
            // 
            // label_reader1
            // 
            this.label_reader1.AutoSize = true;
            this.label_reader1.Location = new System.Drawing.Point(10, 14);
            this.label_reader1.Name = "label_reader1";
            this.label_reader1.Size = new System.Drawing.Size(44, 12);
            this.label_reader1.TabIndex = 21;
            this.label_reader1.Text = "Reader1";
            // 
            // textBox_reader_ip1
            // 
            // 
            // 
            // 
            this.textBox_reader_ip1.CustomButton.Image = null;
            this.textBox_reader_ip1.CustomButton.Location = new System.Drawing.Point(51, 2);
            this.textBox_reader_ip1.CustomButton.Name = "";
            this.textBox_reader_ip1.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.textBox_reader_ip1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox_reader_ip1.CustomButton.TabIndex = 1;
            this.textBox_reader_ip1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox_reader_ip1.CustomButton.UseSelectable = true;
            this.textBox_reader_ip1.CustomButton.Visible = false;
            this.textBox_reader_ip1.Lines = new string[] {
        "10.19.1.55"};
            this.textBox_reader_ip1.Location = new System.Drawing.Point(60, 9);
            this.textBox_reader_ip1.MaxLength = 32767;
            this.textBox_reader_ip1.Name = "textBox_reader_ip1";
            this.textBox_reader_ip1.PasswordChar = '\0';
            this.textBox_reader_ip1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_reader_ip1.SelectedText = "";
            this.textBox_reader_ip1.SelectionLength = 0;
            this.textBox_reader_ip1.SelectionStart = 0;
            this.textBox_reader_ip1.ShortcutsEnabled = true;
            this.textBox_reader_ip1.Size = new System.Drawing.Size(71, 22);
            this.textBox_reader_ip1.TabIndex = 22;
            this.textBox_reader_ip1.Text = "10.19.1.55";
            this.textBox_reader_ip1.UseSelectable = true;
            this.textBox_reader_ip1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_reader_ip1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // button_reader_conn1
            // 
            this.button_reader_conn1.Location = new System.Drawing.Point(137, 8);
            this.button_reader_conn1.Name = "button_reader_conn1";
            this.button_reader_conn1.Size = new System.Drawing.Size(54, 23);
            this.button_reader_conn1.TabIndex = 23;
            this.button_reader_conn1.Tag = "0";
            this.button_reader_conn1.Text = "連線";
            this.button_reader_conn1.UseVisualStyleBackColor = true;
            this.button_reader_conn1.Click += new System.EventHandler(this.button_conn0_Click);
            // 
            // button_reader_conn2
            // 
            this.button_reader_conn2.Location = new System.Drawing.Point(137, 36);
            this.button_reader_conn2.Name = "button_reader_conn2";
            this.button_reader_conn2.Size = new System.Drawing.Size(54, 23);
            this.button_reader_conn2.TabIndex = 26;
            this.button_reader_conn2.Tag = "1";
            this.button_reader_conn2.Text = "連線";
            this.button_reader_conn2.UseVisualStyleBackColor = true;
            this.button_reader_conn2.Click += new System.EventHandler(this.button_conn0_Click);
            // 
            // textBox_reader_ip2
            // 
            // 
            // 
            // 
            this.textBox_reader_ip2.CustomButton.Image = null;
            this.textBox_reader_ip2.CustomButton.Location = new System.Drawing.Point(51, 2);
            this.textBox_reader_ip2.CustomButton.Name = "";
            this.textBox_reader_ip2.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.textBox_reader_ip2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox_reader_ip2.CustomButton.TabIndex = 1;
            this.textBox_reader_ip2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox_reader_ip2.CustomButton.UseSelectable = true;
            this.textBox_reader_ip2.CustomButton.Visible = false;
            this.textBox_reader_ip2.Lines = new string[] {
        "10.19.1.56"};
            this.textBox_reader_ip2.Location = new System.Drawing.Point(60, 37);
            this.textBox_reader_ip2.MaxLength = 32767;
            this.textBox_reader_ip2.Name = "textBox_reader_ip2";
            this.textBox_reader_ip2.PasswordChar = '\0';
            this.textBox_reader_ip2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_reader_ip2.SelectedText = "";
            this.textBox_reader_ip2.SelectionLength = 0;
            this.textBox_reader_ip2.SelectionStart = 0;
            this.textBox_reader_ip2.ShortcutsEnabled = true;
            this.textBox_reader_ip2.Size = new System.Drawing.Size(71, 22);
            this.textBox_reader_ip2.TabIndex = 25;
            this.textBox_reader_ip2.Text = "10.19.1.56";
            this.textBox_reader_ip2.UseSelectable = true;
            this.textBox_reader_ip2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_reader_ip2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label_reader2
            // 
            this.label_reader2.AutoSize = true;
            this.label_reader2.Location = new System.Drawing.Point(10, 42);
            this.label_reader2.Name = "label_reader2";
            this.label_reader2.Size = new System.Drawing.Size(44, 12);
            this.label_reader2.TabIndex = 24;
            this.label_reader2.Text = "Reader2";
            // 
            // button_reader_conn3
            // 
            this.button_reader_conn3.Location = new System.Drawing.Point(137, 64);
            this.button_reader_conn3.Name = "button_reader_conn3";
            this.button_reader_conn3.Size = new System.Drawing.Size(54, 23);
            this.button_reader_conn3.TabIndex = 29;
            this.button_reader_conn3.Tag = "2";
            this.button_reader_conn3.Text = "連線";
            this.button_reader_conn3.UseVisualStyleBackColor = true;
            this.button_reader_conn3.Click += new System.EventHandler(this.button_conn0_Click);
            // 
            // textBox_reader_ip3
            // 
            // 
            // 
            // 
            this.textBox_reader_ip3.CustomButton.Image = null;
            this.textBox_reader_ip3.CustomButton.Location = new System.Drawing.Point(51, 2);
            this.textBox_reader_ip3.CustomButton.Name = "";
            this.textBox_reader_ip3.CustomButton.Size = new System.Drawing.Size(17, 17);
            this.textBox_reader_ip3.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox_reader_ip3.CustomButton.TabIndex = 1;
            this.textBox_reader_ip3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox_reader_ip3.CustomButton.UseSelectable = true;
            this.textBox_reader_ip3.CustomButton.Visible = false;
            this.textBox_reader_ip3.Lines = new string[0];
            this.textBox_reader_ip3.Location = new System.Drawing.Point(60, 65);
            this.textBox_reader_ip3.MaxLength = 32767;
            this.textBox_reader_ip3.Name = "textBox_reader_ip3";
            this.textBox_reader_ip3.PasswordChar = '\0';
            this.textBox_reader_ip3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_reader_ip3.SelectedText = "";
            this.textBox_reader_ip3.SelectionLength = 0;
            this.textBox_reader_ip3.SelectionStart = 0;
            this.textBox_reader_ip3.ShortcutsEnabled = true;
            this.textBox_reader_ip3.Size = new System.Drawing.Size(71, 22);
            this.textBox_reader_ip3.TabIndex = 28;
            this.textBox_reader_ip3.UseSelectable = true;
            this.textBox_reader_ip3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_reader_ip3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label_reader3
            // 
            this.label_reader3.AutoSize = true;
            this.label_reader3.Location = new System.Drawing.Point(10, 70);
            this.label_reader3.Name = "label_reader3";
            this.label_reader3.Size = new System.Drawing.Size(44, 12);
            this.label_reader3.TabIndex = 27;
            this.label_reader3.Text = "Reader3";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox1.Controls.Add(this.label_dup);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label_buffered);
            this.groupBox1.Controls.Add(this.label_upload);
            this.groupBox1.Controls.Add(this.label_total);
            this.groupBox1.Controls.Add(this.label_tagged);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 161);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "人數資訊";
            // 
            // label_dup
            // 
            this.label_dup.AutoSize = true;
            this.label_dup.Location = new System.Drawing.Point(115, 104);
            this.label_dup.Name = "label_dup";
            this.label_dup.Size = new System.Drawing.Size(11, 12);
            this.label_dup.TabIndex = 9;
            this.label_dup.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "組別錯誤人數：";
            // 
            // label_buffered
            // 
            this.label_buffered.AutoSize = true;
            this.label_buffered.Location = new System.Drawing.Point(115, 83);
            this.label_buffered.Name = "label_buffered";
            this.label_buffered.Size = new System.Drawing.Size(11, 12);
            this.label_buffered.TabIndex = 7;
            this.label_buffered.Text = "0";
            // 
            // label_upload
            // 
            this.label_upload.AutoSize = true;
            this.label_upload.Location = new System.Drawing.Point(115, 62);
            this.label_upload.Name = "label_upload";
            this.label_upload.Size = new System.Drawing.Size(11, 12);
            this.label_upload.TabIndex = 6;
            this.label_upload.Text = "0";
            // 
            // label_total
            // 
            this.label_total.AutoSize = true;
            this.label_total.Location = new System.Drawing.Point(115, 42);
            this.label_total.Name = "label_total";
            this.label_total.Size = new System.Drawing.Size(11, 12);
            this.label_total.TabIndex = 5;
            this.label_total.Text = "0";
            // 
            // label_tagged
            // 
            this.label_tagged.AutoSize = true;
            this.label_tagged.Location = new System.Drawing.Point(115, 21);
            this.label_tagged.Name = "label_tagged";
            this.label_tagged.Size = new System.Drawing.Size(11, 12);
            this.label_tagged.TabIndex = 4;
            this.label_tagged.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "待上傳人數：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "活動人數：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 64);
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
            this.textBox_log.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.textBox_log.CustomButton.Image = null;
            this.textBox_log.CustomButton.Location = new System.Drawing.Point(-7, 2);
            this.textBox_log.CustomButton.Name = "";
            this.textBox_log.CustomButton.Size = new System.Drawing.Size(323, 323);
            this.textBox_log.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBox_log.CustomButton.TabIndex = 1;
            this.textBox_log.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBox_log.CustomButton.UseSelectable = true;
            this.textBox_log.CustomButton.Visible = false;
            this.textBox_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_log.Lines = new string[0];
            this.textBox_log.Location = new System.Drawing.Point(203, 3);
            this.textBox_log.MaxLength = 32767;
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.PasswordChar = '\0';
            this.tableLayoutPanel1.SetRowSpan(this.textBox_log, 2);
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox_log.SelectedText = "";
            this.textBox_log.SelectionLength = 0;
            this.textBox_log.SelectionStart = 0;
            this.textBox_log.ShortcutsEnabled = true;
            this.textBox_log.Size = new System.Drawing.Size(319, 328);
            this.textBox_log.TabIndex = 31;
            this.textBox_log.UseSelectable = true;
            this.textBox_log.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBox_log.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dgv_group
            // 
            this.dgv_group.AllowUserToAddRows = false;
            this.dgv_group.AllowUserToResizeRows = false;
            this.dgv_group.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgv_group.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_group.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_group.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_group.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_group.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_group.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column10,
            this.Column8,
            this.Column9});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_group.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_group.EnableHeadersVisualStyles = false;
            this.dgv_group.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dgv_group.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgv_group.Location = new System.Drawing.Point(203, 337);
            this.dgv_group.Name = "dgv_group";
            this.dgv_group.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_group.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_group.RowHeadersVisible = false;
            this.dgv_group.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_group.RowTemplate.Height = 24;
            this.dgv_group.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_group.Size = new System.Drawing.Size(319, 162);
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
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column10.FillWeight = 50F;
            this.Column10.HeaderText = "ID";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.FillWeight = 160F;
            this.Column8.HeaderText = "組別名稱";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.FillWeight = 140F;
            this.Column9.HeaderText = "起跑時間";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
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
            this.comboBox_station.Location = new System.Drawing.Point(32, 93);
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
            // checkBox_station
            // 
            this.checkBox_station.AutoSize = true;
            this.checkBox_station.Location = new System.Drawing.Point(31, 121);
            this.checkBox_station.Name = "checkBox_station";
            this.checkBox_station.Size = new System.Drawing.Size(48, 16);
            this.checkBox_station.TabIndex = 37;
            this.checkBox_station.Text = "自訂";
            this.checkBox_station.UseVisualStyleBackColor = true;
            this.checkBox_station.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // textBox_station
            // 
            this.textBox_station.AllowUserToResizeRows = false;
            this.textBox_station.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox_station.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_station.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.textBox_station.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.textBox_station.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.textBox_station.DefaultCellStyle = dataGridViewCellStyle5;
            this.textBox_station.EnableHeadersVisualStyles = false;
            this.textBox_station.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBox_station.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox_station.Location = new System.Drawing.Point(82, 119);
            this.textBox_station.Name = "textBox_station";
            this.textBox_station.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.textBox_station.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.textBox_station.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.textBox_station.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.textBox_station.Size = new System.Drawing.Size(71, 22);
            this.textBox_station.TabIndex = 38;
            this.textBox_station.TextChanged += new System.EventHandler(this.textBox_station_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.7957F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.2043F));
            this.tableLayoutPanel1.Controls.Add(this.metroPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.metroPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.touchedView, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgv_group, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_log, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1191, 502);
            this.tableLayoutPanel1.TabIndex = 40;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.metroPanel2.Controls.Add(this.button2);
            this.metroPanel2.Controls.Add(this.metroButton3);
            this.metroPanel2.Controls.Add(this.metroButton2);
            this.metroPanel2.Controls.Add(this.metroButton1);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(35, 337);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(129, 162);
            this.metroPanel2.TabIndex = 41;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // button2
            // 
            this.button2.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.button2.Location = new System.Drawing.Point(0, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 33);
            this.button2.TabIndex = 43;
            this.button2.Text = "定時工作";
            this.button2.UseSelectable = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // metroButton3
            // 
            this.metroButton3.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton3.Location = new System.Drawing.Point(0, 81);
            this.metroButton3.Name = "metroButton3";
            this.metroButton3.Size = new System.Drawing.Size(120, 33);
            this.metroButton3.TabIndex = 42;
            this.metroButton3.Text = "清除";
            this.metroButton3.UseSelectable = true;
            this.metroButton3.Click += new System.EventHandler(this.button3_Click);
            // 
            // metroButton2
            // 
            this.metroButton2.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton2.Location = new System.Drawing.Point(0, 3);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(120, 33);
            this.metroButton2.TabIndex = 41;
            this.metroButton2.Text = "紀錄鳴槍";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.button1_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton1.Location = new System.Drawing.Point(0, 42);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(120, 33);
            this.metroButton1.TabIndex = 40;
            this.metroButton1.Text = "設定起跑";
            this.metroButton1.UseSelectable = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.metroPanel1.Controls.Add(this.textBox_station);
            this.metroPanel1.Controls.Add(this.label_reader1);
            this.metroPanel1.Controls.Add(this.checkBox_station);
            this.metroPanel1.Controls.Add(this.textBox_reader_ip1);
            this.metroPanel1.Controls.Add(this.button_reader_conn1);
            this.metroPanel1.Controls.Add(this.comboBox_station);
            this.metroPanel1.Controls.Add(this.label_reader2);
            this.metroPanel1.Controls.Add(this.textBox_reader_ip2);
            this.metroPanel1.Controls.Add(this.button_reader_conn2);
            this.metroPanel1.Controls.Add(this.button_reader_conn3);
            this.metroPanel1.Controls.Add(this.label_reader3);
            this.metroPanel1.Controls.Add(this.textBox_reader_ip3);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(3, 3);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(194, 151);
            this.metroPanel1.TabIndex = 41;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // ReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 582);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label_localtime);
            this.Name = "ReaderForm";
            this.Text = "ReaderForm";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReaderForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReaderForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.touchedView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_group)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_station)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroGrid touchedView;
        private System.Windows.Forms.Timer refresh_timer;
        private System.Windows.Forms.Label label_localtime;
        private System.Windows.Forms.Label label_reader1;
        private System.Windows.Forms.Button button_reader_conn1;
        private System.Windows.Forms.Button button_reader_conn2;
        private System.Windows.Forms.Label label_reader2;
        private System.Windows.Forms.Button button_reader_conn3;
        private System.Windows.Forms.Label label_reader3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Controls.MetroGrid dgv_group;
        private System.Windows.Forms.ComboBox comboBox_station;
        private System.Windows.Forms.Label label_buffered;
        private System.Windows.Forms.Label label_upload;
        private System.Windows.Forms.Label label_total;
        private System.Windows.Forms.Label label_tagged;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox checkBox_station;
        private MetroFramework.Controls.MetroGrid  textBox_station;
        private System.Windows.Forms.Label label_dup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton button2;
        private MetroFramework.Controls.MetroButton metroButton3;
        private MetroFramework.Controls.MetroTextBox textBox_reader_ip1;
        private MetroFramework.Controls.MetroTextBox textBox_reader_ip2;
        private MetroFramework.Controls.MetroTextBox textBox_reader_ip3;
        private MetroFramework.Controls.MetroTextBox textBox_log;
    }
}