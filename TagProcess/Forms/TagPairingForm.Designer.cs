namespace TagProcess
{
    partial class TagPairingForm
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
                if(incomingTags != null)incomingTags.Dispose();
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel_API = new System.Windows.Forms.ToolStripStatusLabel();
            this.pairDGV = new System.Windows.Forms.DataGridView();
            this.col_tag_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_pair_button = new System.Windows.Forms.Button();
            this.getTagWorker = new System.ComponentModel.BackgroundWorker();
            this.consumer_timer = new System.Windows.Forms.Timer(this.components);
            this.stop_pair_button = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pairDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.statusLabel_API});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 349);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(436, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // statusLabel_API
            // 
            this.statusLabel_API.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusLabel_API.Name = "statusLabel_API";
            this.statusLabel_API.Size = new System.Drawing.Size(0, 17);
            // 
            // pairDGV
            // 
            this.pairDGV.AllowUserToAddRows = false;
            this.pairDGV.AllowUserToDeleteRows = false;
            this.pairDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pairDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_tag_id,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.pairDGV.Location = new System.Drawing.Point(19, 47);
            this.pairDGV.MultiSelect = false;
            this.pairDGV.Name = "pairDGV";
            this.pairDGV.ReadOnly = true;
            this.pairDGV.RowTemplate.Height = 24;
            this.pairDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.pairDGV.Size = new System.Drawing.Size(396, 285);
            this.pairDGV.TabIndex = 2;
            // 
            // col_tag_id
            // 
            this.col_tag_id.HeaderText = "晶片ID";
            this.col_tag_id.Name = "col_tag_id";
            this.col_tag_id.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "選手號碼";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "姓名";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "組別";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // start_pair_button
            // 
            this.start_pair_button.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.start_pair_button.Location = new System.Drawing.Point(231, 12);
            this.start_pair_button.Name = "start_pair_button";
            this.start_pair_button.Size = new System.Drawing.Size(90, 28);
            this.start_pair_button.TabIndex = 3;
            this.start_pair_button.Text = "開始配對";
            this.start_pair_button.UseVisualStyleBackColor = true;
            this.start_pair_button.Click += new System.EventHandler(this.start_pair_button_Click);
            // 
            // getTagWorker
            // 
            this.getTagWorker.WorkerSupportsCancellation = true;
            this.getTagWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.getTagWorker_DoWork);
            this.getTagWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.getTagWorker_RunWorkerCompleted);
            // 
            // consumer_timer
            // 
            this.consumer_timer.Tick += new System.EventHandler(this.consumer_timer_Tick);
            // 
            // stop_pair_button
            // 
            this.stop_pair_button.Enabled = false;
            this.stop_pair_button.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.stop_pair_button.Location = new System.Drawing.Point(325, 12);
            this.stop_pair_button.Name = "stop_pair_button";
            this.stop_pair_button.Size = new System.Drawing.Size(90, 28);
            this.stop_pair_button.TabIndex = 4;
            this.stop_pair_button.Text = "停止配對";
            this.stop_pair_button.UseVisualStyleBackColor = true;
            this.stop_pair_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // TagPairingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 371);
            this.Controls.Add(this.stop_pair_button);
            this.Controls.Add(this.start_pair_button);
            this.Controls.Add(this.pairDGV);
            this.Controls.Add(this.statusStrip1);
            this.Name = "TagPairingForm";
            this.Text = "晶片配對";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TagPairingForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pairDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView pairDGV;
        private System.Windows.Forms.Button start_pair_button;
        private System.ComponentModel.BackgroundWorker getTagWorker;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Timer consumer_timer;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tag_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_API;
        private System.Windows.Forms.Button stop_pair_button;
    }
}