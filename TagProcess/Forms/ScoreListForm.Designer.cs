namespace TagProcess.Forms
{
    partial class ScoreListForm
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_tag_id = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_race_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_printer = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column9,
            this.Column1,
            this.Column2,
            this.Column7,
            this.Column3,
            this.Column8,
            this.Column4,
            this.Column5,
            this.Column10,
            this.Column6,
            this.Column11,
            this.Column12,
            this.Column13});
            this.dgv.Location = new System.Drawing.Point(12, 115);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(1134, 339);
            this.dgv.TabIndex = 0;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column9
            // 
            this.Column9.HeaderText = "狀態";
            this.Column9.Name = "Column9";
            // 
            // Column1
            // 
            this.Column1.FillWeight = 80F;
            this.Column1.HeaderText = "參賽編號";
            this.Column1.MaxInputLength = 5;
            this.Column1.Name = "Column1";
            this.Column1.Width = 80;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 80F;
            this.Column2.HeaderText = "姓名";
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "團隊名稱";
            this.Column7.Name = "Column7";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "參賽組別";
            this.Column3.Name = "Column3";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "組別種類";
            this.Column8.Name = "Column8";
            // 
            // Column4
            // 
            this.Column4.FillWeight = 70F;
            this.Column4.HeaderText = "總名次";
            this.Column4.Name = "Column4";
            this.Column4.Width = 70;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 80F;
            this.Column5.HeaderText = "組別名次";
            this.Column5.Name = "Column5";
            this.Column5.Width = 80;
            // 
            // Column10
            // 
            this.Column10.FillWeight = 120F;
            this.Column10.HeaderText = "大會成績";
            this.Column10.Name = "Column10";
            this.Column10.Width = 120;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 120F;
            this.Column6.HeaderText = "個人成績";
            this.Column6.Name = "Column6";
            this.Column6.Width = 120;
            // 
            // Column11
            // 
            this.Column11.FillWeight = 170F;
            this.Column11.HeaderText = "大會起跑時間";
            this.Column11.Name = "Column11";
            this.Column11.Width = 170;
            // 
            // Column12
            // 
            this.Column12.FillWeight = 170F;
            this.Column12.HeaderText = "個人起跑時間";
            this.Column12.Name = "Column12";
            this.Column12.Width = 170;
            // 
            // Column13
            // 
            this.Column13.FillWeight = 170F;
            this.Column13.HeaderText = "終點時間";
            this.Column13.Name = "Column13";
            this.Column13.Width = 170;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_tag_id);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox_race_id);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "搜尋";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "晶片感應";
            // 
            // textBox_tag_id
            // 
            this.textBox_tag_id.Location = new System.Drawing.Point(86, 53);
            this.textBox_tag_id.Name = "textBox_tag_id";
            this.textBox_tag_id.Size = new System.Drawing.Size(182, 27);
            this.textBox_tag_id.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "晶片感應";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_race_id
            // 
            this.textBox_race_id.Location = new System.Drawing.Point(86, 20);
            this.textBox_race_id.Name = "textBox_race_id";
            this.textBox_race_id.Size = new System.Drawing.Size(76, 27);
            this.textBox_race_id.TabIndex = 1;
            this.textBox_race_id.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_race_id_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "參賽編號";
            // 
            // cb_printer
            // 
            this.cb_printer.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cb_printer.FormattingEnabled = true;
            this.cb_printer.Location = new System.Drawing.Point(504, 29);
            this.cb_printer.Name = "cb_printer";
            this.cb_printer.Size = new System.Drawing.Size(206, 24);
            this.cb_printer.TabIndex = 2;
            // 
            // ScoreListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 466);
            this.Controls.Add(this.cb_printer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgv);
            this.Name = "ScoreListForm";
            this.Text = "成績列表";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_race_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_tag_id;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.ComboBox cb_printer;
    }
}