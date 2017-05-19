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
            this.pairDGV = new System.Windows.Forms.DataGridView();
            this.start_pair_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.getTagWorker = new System.ComponentModel.BackgroundWorker();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.consumer_timer = new System.Windows.Forms.Timer(this.components);
            this.col_tag_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pairDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 349);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(436, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
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
            // start_pair_button
            // 
            this.start_pair_button.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.start_pair_button.Location = new System.Drawing.Point(209, 13);
            this.start_pair_button.Name = "start_pair_button";
            this.start_pair_button.Size = new System.Drawing.Size(90, 28);
            this.start_pair_button.TabIndex = 3;
            this.start_pair_button.Text = "開始配對";
            this.start_pair_button.UseVisualStyleBackColor = true;
            this.start_pair_button.Click += new System.EventHandler(this.start_pair_button_Click);
            // 
            // save_button
            // 
            this.save_button.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.save_button.Location = new System.Drawing.Point(325, 13);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(90, 28);
            this.save_button.TabIndex = 4;
            this.save_button.Text = "儲存變更";
            this.save_button.UseVisualStyleBackColor = true;
            // 
            // getTagWorker
            // 
            this.getTagWorker.WorkerSupportsCancellation = true;
            this.getTagWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.getTagWorker_DoWork);
            this.getTagWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.getTagWorker_RunWorkerCompleted);
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // consumer_timer
            // 
            this.consumer_timer.Tick += new System.EventHandler(this.consumer_timer_Tick);
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
            // TagPairingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 371);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.start_pair_button);
            this.Controls.Add(this.pairDGV);
            this.Controls.Add(this.statusStrip1);
            this.Name = "TagPairingForm";
            this.Text = "晶片配對";
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
        private System.Windows.Forms.Button save_button;
        private System.ComponentModel.BackgroundWorker getTagWorker;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Timer consumer_timer;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tag_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}