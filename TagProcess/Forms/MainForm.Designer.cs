namespace TagProcess
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pair_form_button = new System.Windows.Forms.Button();
            this.print_mail_button = new System.Windows.Forms.Button();
            this.partcipants_view_button = new System.Windows.Forms.Button();
            this.import_button = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.output_StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel_tag = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.COMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重新整理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.伺服器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.log檔ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excelWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.printScore = new System.Windows.Forms.Button();
            this.reader_button = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pair_form_button);
            this.groupBox1.Controls.Add(this.print_mail_button);
            this.groupBox1.Controls.Add(this.partcipants_view_button);
            this.groupBox1.Controls.Add(this.import_button);
            this.groupBox1.Location = new System.Drawing.Point(13, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 85);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "資料作業";
            // 
            // pair_form_button
            // 
            this.pair_form_button.Location = new System.Drawing.Point(88, 52);
            this.pair_form_button.Name = "pair_form_button";
            this.pair_form_button.Size = new System.Drawing.Size(75, 23);
            this.pair_form_button.TabIndex = 3;
            this.pair_form_button.Text = "晶片配對";
            this.pair_form_button.UseVisualStyleBackColor = true;
            this.pair_form_button.Click += new System.EventHandler(this.pair_form_button_Click);
            // 
            // print_mail_button
            // 
            this.print_mail_button.Location = new System.Drawing.Point(88, 23);
            this.print_mail_button.Name = "print_mail_button";
            this.print_mail_button.Size = new System.Drawing.Size(75, 23);
            this.print_mail_button.TabIndex = 2;
            this.print_mail_button.Text = "列印標籤";
            this.print_mail_button.UseVisualStyleBackColor = true;
            this.print_mail_button.Click += new System.EventHandler(this.print_mail_button_Click);
            // 
            // partcipants_view_button
            // 
            this.partcipants_view_button.Location = new System.Drawing.Point(7, 52);
            this.partcipants_view_button.Name = "partcipants_view_button";
            this.partcipants_view_button.Size = new System.Drawing.Size(75, 23);
            this.partcipants_view_button.TabIndex = 1;
            this.partcipants_view_button.Text = "檢視資料";
            this.partcipants_view_button.UseVisualStyleBackColor = true;
            this.partcipants_view_button.Click += new System.EventHandler(this.partcipants_view_button_Click);
            // 
            // import_button
            // 
            this.import_button.Location = new System.Drawing.Point(7, 22);
            this.import_button.Name = "import_button";
            this.import_button.Size = new System.Drawing.Size(75, 23);
            this.import_button.TabIndex = 0;
            this.import_button.Text = "匯入資料";
            this.import_button.UseVisualStyleBackColor = true;
            this.import_button.Click += new System.EventHandler(this.import_button_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.output_StatusLabel,
            this.statusLabel_tag});
            this.statusStrip1.Location = new System.Drawing.Point(0, 121);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(387, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // output_StatusLabel
            // 
            this.output_StatusLabel.Name = "output_StatusLabel";
            this.output_StatusLabel.Size = new System.Drawing.Size(372, 17);
            this.output_StatusLabel.Spring = true;
            this.output_StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusLabel_tag
            // 
            this.statusLabel_tag.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusLabel_tag.Name = "statusLabel_tag";
            this.statusLabel_tag.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.設定ToolStripMenuItem,
            this.log檔ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(387, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 設定ToolStripMenuItem
            // 
            this.設定ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.COMToolStripMenuItem,
            this.伺服器ToolStripMenuItem});
            this.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            this.設定ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.設定ToolStripMenuItem.Text = "設定";
            // 
            // COMToolStripMenuItem
            // 
            this.COMToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重新整理ToolStripMenuItem});
            this.COMToolStripMenuItem.Name = "COMToolStripMenuItem";
            this.COMToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.COMToolStripMenuItem.Text = "COM";
            // 
            // 重新整理ToolStripMenuItem
            // 
            this.重新整理ToolStripMenuItem.Name = "重新整理ToolStripMenuItem";
            this.重新整理ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.重新整理ToolStripMenuItem.Text = "重新整理";
            this.重新整理ToolStripMenuItem.Click += new System.EventHandler(this.重新整理ToolStripMenuItem_Click);
            // 
            // 伺服器ToolStripMenuItem
            // 
            this.伺服器ToolStripMenuItem.Name = "伺服器ToolStripMenuItem";
            this.伺服器ToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.伺服器ToolStripMenuItem.Text = "伺服器";
            this.伺服器ToolStripMenuItem.Click += new System.EventHandler(this.伺服器ToolStripMenuItem_Click);
            // 
            // log檔ToolStripMenuItem
            // 
            this.log檔ToolStripMenuItem.Name = "log檔ToolStripMenuItem";
            this.log檔ToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.log檔ToolStripMenuItem.Text = "Log檔";
            this.log檔ToolStripMenuItem.Click += new System.EventHandler(this.log檔ToolStripMenuItem_Click);
            // 
            // excelWorker
            // 
            this.excelWorker.WorkerReportsProgress = true;
            this.excelWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.excelWorker_DoWork);
            this.excelWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.excelWorker_ProgressChanged);
            this.excelWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.excelWorker_RunWorkerCompleted);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.printScore);
            this.groupBox2.Controls.Add(this.reader_button);
            this.groupBox2.Location = new System.Drawing.Point(196, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(176, 83);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "現場作業";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(89, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "成績統整";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // printScore
            // 
            this.printScore.Location = new System.Drawing.Point(7, 49);
            this.printScore.Name = "printScore";
            this.printScore.Size = new System.Drawing.Size(75, 23);
            this.printScore.TabIndex = 1;
            this.printScore.Text = "成績列印";
            this.printScore.UseVisualStyleBackColor = true;
            this.printScore.Click += new System.EventHandler(this.printScore_Click);
            // 
            // reader_button
            // 
            this.reader_button.Location = new System.Drawing.Point(7, 21);
            this.reader_button.Name = "reader_button";
            this.reader_button.Size = new System.Drawing.Size(75, 23);
            this.reader_button.TabIndex = 0;
            this.reader_button.Text = "晶片計時";
            this.reader_button.UseVisualStyleBackColor = true;
            this.reader_button.Click += new System.EventHandler(this.reader_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 143);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "主選單";
            this.groupBox1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button pair_form_button;
        private System.Windows.Forms.Button print_mail_button;
        private System.Windows.Forms.Button partcipants_view_button;
        private System.Windows.Forms.Button import_button;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem COMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 伺服器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel output_StatusLabel;
        private System.Windows.Forms.ToolStripMenuItem 重新整理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_tag;
        private System.Windows.Forms.ToolStripMenuItem log檔ToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker excelWorker;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button printScore;
        private System.Windows.Forms.Button reader_button;
    }
}

