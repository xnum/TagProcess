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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel_API = new System.Windows.Forms.ToolStripStatusLabel();
            this.pairDGV = new MetroFramework.Controls.MetroGrid();
            this.col_tag_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start_pair_button = new System.Windows.Forms.Button();
            this.getTagWorker = new System.ComponentModel.BackgroundWorker();
            this.consumer_timer = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.stop_pair_button = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pairDGV)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.statusLabel_API});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(20, 384);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(639, 22);
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
            this.pairDGV.AllowUserToResizeRows = false;
            this.pairDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pairDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pairDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.pairDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pairDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.pairDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pairDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_tag_id,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.tableLayoutPanel1.SetColumnSpan(this.pairDGV, 3);
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.pairDGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.pairDGV.EnableHeadersVisualStyles = false;
            this.pairDGV.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.pairDGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pairDGV.Location = new System.Drawing.Point(3, 34);
            this.pairDGV.MultiSelect = false;
            this.pairDGV.Name = "pairDGV";
            this.pairDGV.ReadOnly = true;
            this.pairDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pairDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.pairDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.pairDGV.RowTemplate.Height = 24;
            this.pairDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.pairDGV.Size = new System.Drawing.Size(626, 277);
            this.pairDGV.TabIndex = 2;
            // 
            // col_tag_id
            // 
            this.col_tag_id.HeaderText = "晶片ID";
            this.col_tag_id.Name = "col_tag_id";
            this.col_tag_id.ReadOnly = true;
            this.col_tag_id.Width = 120;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "選手號碼";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "姓名";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "組別";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 200;
            // 
            // start_pair_button
            // 
            this.start_pair_button.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.start_pair_button.Location = new System.Drawing.Point(453, 3);
            this.start_pair_button.Name = "start_pair_button";
            this.start_pair_button.Size = new System.Drawing.Size(80, 25);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.20253F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.60759F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.03165F));
            this.tableLayoutPanel1.Controls.Add(this.start_pair_button, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.stop_pair_button, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.pairDGV, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 63);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.15873F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.84127F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(632, 315);
            this.tableLayoutPanel1.TabIndex = 5;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // stop_pair_button
            // 
            this.stop_pair_button.Enabled = false;
            this.stop_pair_button.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.stop_pair_button.Location = new System.Drawing.Point(539, 3);
            this.stop_pair_button.Name = "stop_pair_button";
            this.stop_pair_button.Size = new System.Drawing.Size(90, 25);
            this.stop_pair_button.TabIndex = 4;
            this.stop_pair_button.Text = "停止配對";
            this.stop_pair_button.UseVisualStyleBackColor = true;
            this.stop_pair_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // TagPairingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 426);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "TagPairingForm";
            this.Resizable = false;
            this.Text = "晶片配對";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TagPairingForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pairDGV)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        //private System.Windows.Forms.DataGridView pairDGV;
        private System.Windows.Forms.Button start_pair_button;
        private System.ComponentModel.BackgroundWorker getTagWorker;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Timer consumer_timer;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_API;
        private MetroFramework.Controls.MetroGrid pairDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tag_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button stop_pair_button;
    }
}