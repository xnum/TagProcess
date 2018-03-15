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
            this.components = new System.ComponentModel.Container();
            this.grpbUnused1 = new System.Windows.Forms.GroupBox();
            this.btnShowTagPairingForm = new MetroFramework.Controls.MetroButton();
            this.btnPrintMailLabel = new MetroFramework.Controls.MetroButton();
            this.btnShowParticipantsViewForm = new MetroFramework.Controls.MetroButton();
            this.btnImportData = new MetroFramework.Controls.MetroButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblTag = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiComPort = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiServerUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLogFile = new System.Windows.Forms.ToolStripMenuItem();
            this.grpbUnused2 = new System.Windows.Forms.GroupBox();
            this.btnScoreReview = new MetroFramework.Controls.MetroButton();
            this.btnPrintScore = new MetroFramework.Controls.MetroButton();
            this.btnShowReaderForm = new MetroFramework.Controls.MetroButton();
            this.panel_main = new MetroFramework.Controls.MetroPanel();
            this.panel_act = new MetroFramework.Controls.MetroPanel();
            this.button_choose_act = new MetroFramework.Controls.MetroButton();
            this.comboBox_act = new MetroFramework.Controls.MetroComboBox();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.metroStyleExtender2 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.metroStyleExtender3 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.grpbUnused1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.grpbUnused2.SuspendLayout();
            this.panel_main.SuspendLayout();
            this.panel_act.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpbUnused1
            // 
            this.grpbUnused1.Controls.Add(this.btnShowTagPairingForm);
            this.grpbUnused1.Controls.Add(this.btnPrintMailLabel);
            this.grpbUnused1.Controls.Add(this.btnShowParticipantsViewForm);
            this.grpbUnused1.Controls.Add(this.btnImportData);
            this.grpbUnused1.Location = new System.Drawing.Point(14, 19);
            this.grpbUnused1.Name = "grpbUnused1";
            this.grpbUnused1.Size = new System.Drawing.Size(227, 134);
            this.grpbUnused1.TabIndex = 0;
            this.grpbUnused1.TabStop = false;
            this.grpbUnused1.Text = "資料作業";
            // 
            // btnShowTagPairingForm
            // 
            this.btnShowTagPairingForm.Location = new System.Drawing.Point(121, 77);
            this.btnShowTagPairingForm.Name = "btnShowTagPairingForm";
            this.btnShowTagPairingForm.Size = new System.Drawing.Size(100, 50);
            this.btnShowTagPairingForm.TabIndex = 3;
            this.btnShowTagPairingForm.Text = "晶片配對";
            this.btnShowTagPairingForm.UseSelectable = true;
            this.btnShowTagPairingForm.Click += new System.EventHandler(this.btnShowTagPairingForm_Click);
            // 
            // btnPrintMailLabel
            // 
            this.btnPrintMailLabel.Location = new System.Drawing.Point(121, 21);
            this.btnPrintMailLabel.Name = "btnPrintMailLabel";
            this.btnPrintMailLabel.Size = new System.Drawing.Size(100, 50);
            this.btnPrintMailLabel.TabIndex = 2;
            this.btnPrintMailLabel.Text = "列印標籤";
            this.btnPrintMailLabel.UseSelectable = true;
            this.btnPrintMailLabel.Click += new System.EventHandler(this.btnPrintMailLabel_Click);
            // 
            // btnShowParticipantsViewForm
            // 
            this.btnShowParticipantsViewForm.Location = new System.Drawing.Point(11, 77);
            this.btnShowParticipantsViewForm.Name = "btnShowParticipantsViewForm";
            this.btnShowParticipantsViewForm.Size = new System.Drawing.Size(100, 50);
            this.btnShowParticipantsViewForm.TabIndex = 1;
            this.btnShowParticipantsViewForm.Text = "檢視資料";
            this.btnShowParticipantsViewForm.UseSelectable = true;
            this.btnShowParticipantsViewForm.Click += new System.EventHandler(this.btnShowPartcipantsViewForm_Click);
            // 
            // btnImportData
            // 
            this.btnImportData.Location = new System.Drawing.Point(11, 21);
            this.btnImportData.Name = "btnImportData";
            this.btnImportData.Size = new System.Drawing.Size(100, 50);
            this.btnImportData.TabIndex = 0;
            this.btnImportData.Text = "匯入資料";
            this.btnImportData.UseSelectable = true;
            this.btnImportData.Click += new System.EventHandler(this.btnImportData_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slblStatus,
            this.slblTag});
            this.statusStrip1.Location = new System.Drawing.Point(20, 256);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(481, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slblStatus
            // 
            this.slblStatus.Name = "slblStatus";
            this.slblStatus.Size = new System.Drawing.Size(466, 17);
            this.slblStatus.Spring = true;
            this.slblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // slblTag
            // 
            this.slblTag.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.slblTag.Name = "slblTag";
            this.slblTag.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSetup,
            this.tsmiLogFile});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(481, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiSetup
            // 
            this.tsmiSetup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiComPort,
            this.tsmiServerUrl});
            this.tsmiSetup.Name = "tsmiSetup";
            this.tsmiSetup.Size = new System.Drawing.Size(43, 20);
            this.tsmiSetup.Text = "設定";
            // 
            // tsmiComPort
            // 
            this.tsmiComPort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRefresh});
            this.tsmiComPort.Name = "tsmiComPort";
            this.tsmiComPort.Size = new System.Drawing.Size(110, 22);
            this.tsmiComPort.Text = "COM";
            // 
            // tsmiRefresh
            // 
            this.tsmiRefresh.Name = "tsmiRefresh";
            this.tsmiRefresh.Size = new System.Drawing.Size(122, 22);
            this.tsmiRefresh.Text = "重新整理";
            this.tsmiRefresh.Click += new System.EventHandler(this.tsmiRefresh_Click);
            // 
            // tsmiServerUrl
            // 
            this.tsmiServerUrl.Name = "tsmiServerUrl";
            this.tsmiServerUrl.Size = new System.Drawing.Size(110, 22);
            this.tsmiServerUrl.Text = "伺服器";
            this.tsmiServerUrl.Click += new System.EventHandler(this.tsmiServerUrl_Click);
            // 
            // tsmiLogFile
            // 
            this.tsmiLogFile.Name = "tsmiLogFile";
            this.tsmiLogFile.Size = new System.Drawing.Size(53, 20);
            this.tsmiLogFile.Text = "Log檔";
            this.tsmiLogFile.Click += new System.EventHandler(this.tsmiLogFile_Click);
            // 
            // grpbUnused2
            // 
            this.grpbUnused2.Controls.Add(this.btnScoreReview);
            this.grpbUnused2.Controls.Add(this.btnPrintScore);
            this.grpbUnused2.Controls.Add(this.btnShowReaderForm);
            this.grpbUnused2.Location = new System.Drawing.Point(247, 19);
            this.grpbUnused2.Name = "grpbUnused2";
            this.grpbUnused2.Size = new System.Drawing.Size(219, 134);
            this.grpbUnused2.TabIndex = 4;
            this.grpbUnused2.TabStop = false;
            this.grpbUnused2.Text = "現場作業";
            // 
            // btnScoreReview
            // 
            this.btnScoreReview.Location = new System.Drawing.Point(113, 21);
            this.btnScoreReview.Name = "btnScoreReview";
            this.btnScoreReview.Size = new System.Drawing.Size(100, 50);
            this.btnScoreReview.TabIndex = 6;
            this.btnScoreReview.Text = "成績修正";
            this.btnScoreReview.UseSelectable = true;
            this.btnScoreReview.Click += new System.EventHandler(this.btnScoreReview_Click);
            // 
            // btnPrintScore
            // 
            this.btnPrintScore.Location = new System.Drawing.Point(7, 77);
            this.btnPrintScore.Name = "btnPrintScore";
            this.btnPrintScore.Size = new System.Drawing.Size(100, 50);
            this.btnPrintScore.TabIndex = 5;
            this.btnPrintScore.Text = "列印成績";
            this.btnPrintScore.UseSelectable = true;
            this.btnPrintScore.Click += new System.EventHandler(this.printScore_Click);
            // 
            // btnShowReaderForm
            // 
            this.btnShowReaderForm.Location = new System.Drawing.Point(7, 21);
            this.btnShowReaderForm.Name = "btnShowReaderForm";
            this.btnShowReaderForm.Size = new System.Drawing.Size(100, 50);
            this.btnShowReaderForm.TabIndex = 0;
            this.btnShowReaderForm.Text = "晶片計時";
            this.btnShowReaderForm.UseSelectable = true;
            this.btnShowReaderForm.Click += new System.EventHandler(this.btnShowReaderForm_Click);
            // 
            // panel_main
            // 
            this.panel_main.Controls.Add(this.grpbUnused2);
            this.panel_main.Controls.Add(this.grpbUnused1);
            this.panel_main.HorizontalScrollbarBarColor = true;
            this.panel_main.HorizontalScrollbarHighlightOnWheel = false;
            this.panel_main.HorizontalScrollbarSize = 10;
            this.panel_main.Location = new System.Drawing.Point(23, 86);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(478, 167);
            this.panel_main.TabIndex = 5;
            this.panel_main.VerticalScrollbarBarColor = true;
            this.panel_main.VerticalScrollbarHighlightOnWheel = false;
            this.panel_main.VerticalScrollbarSize = 10;
            // 
            // panel_act
            // 
            this.panel_act.Controls.Add(this.button_choose_act);
            this.panel_act.Controls.Add(this.comboBox_act);
            this.panel_act.HorizontalScrollbarBarColor = true;
            this.panel_act.HorizontalScrollbarHighlightOnWheel = false;
            this.panel_act.HorizontalScrollbarSize = 10;
            this.panel_act.Location = new System.Drawing.Point(22, 87);
            this.panel_act.Name = "panel_act";
            this.panel_act.Size = new System.Drawing.Size(479, 166);
            this.panel_act.TabIndex = 5;
            this.panel_act.VerticalScrollbarBarColor = true;
            this.panel_act.VerticalScrollbarHighlightOnWheel = false;
            this.panel_act.VerticalScrollbarSize = 10;
            // 
            // button_choose_act
            // 
            this.button_choose_act.Location = new System.Drawing.Point(296, 50);
            this.button_choose_act.Name = "button_choose_act";
            this.button_choose_act.Size = new System.Drawing.Size(93, 30);
            this.button_choose_act.TabIndex = 1;
            this.button_choose_act.Text = "選擇活動";
            this.button_choose_act.UseSelectable = true;
            this.button_choose_act.Click += new System.EventHandler(this.button_choose_act_Click);
            // 
            // comboBox_act
            // 
            this.comboBox_act.FormattingEnabled = true;
            this.comboBox_act.ItemHeight = 23;
            this.comboBox_act.Location = new System.Drawing.Point(26, 51);
            this.comboBox_act.Name = "comboBox_act";
            this.comboBox_act.Size = new System.Drawing.Size(263, 29);
            this.comboBox_act.TabIndex = 0;
            this.comboBox_act.UseSelectable = true;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = null;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 298);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel_act);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "主選單";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.grpbUnused1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpbUnused2.ResumeLayout(false);
            this.panel_main.ResumeLayout(false);
            this.panel_act.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbUnused1;
        private System.Windows.Forms.GroupBox grpbUnused2;

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetup;
        private System.Windows.Forms.ToolStripMenuItem tsmiComPort;
        private System.Windows.Forms.ToolStripMenuItem tsmiServerUrl;
        
        private System.Windows.Forms.ToolStripMenuItem tsmiRefresh;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogFile;

        private System.Windows.Forms.ToolStripStatusLabel slblStatus;
        private System.Windows.Forms.ToolStripStatusLabel slblTag;
        private MetroFramework.Controls.MetroPanel panel_main;
        private MetroFramework.Controls.MetroPanel panel_act;
        private MetroFramework.Controls.MetroButton button_choose_act;
        private MetroFramework.Controls.MetroComboBox comboBox_act;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroButton btnShowTagPairingForm;
        private MetroFramework.Controls.MetroButton btnPrintMailLabel;
        private MetroFramework.Controls.MetroButton btnShowParticipantsViewForm;
        private MetroFramework.Controls.MetroButton btnImportData;
        private MetroFramework.Controls.MetroButton btnShowReaderForm;
        private MetroFramework.Controls.MetroButton btnPrintScore;
        private MetroFramework.Controls.MetroButton btnScoreReview;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender2;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender3;
    }
}

