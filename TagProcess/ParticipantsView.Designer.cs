namespace TagProcess
{
    partial class ParticipantsView
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
            this.mainDGV = new System.Windows.Forms.DataGridView();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_birth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_male = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_race_group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_race_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // mainDGV
            // 
            this.mainDGV.AllowUserToAddRows = false;
            this.mainDGV.AllowUserToDeleteRows = false;
            this.mainDGV.AllowUserToOrderColumns = true;
            this.mainDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id,
            this.col_name,
            this.col_birth,
            this.col_male,
            this.col_race_group,
            this.col_tag,
            this.col_race_id,
            this.col_edit});
            this.mainDGV.Location = new System.Drawing.Point(12, 46);
            this.mainDGV.MultiSelect = false;
            this.mainDGV.Name = "mainDGV";
            this.mainDGV.ReadOnly = true;
            this.mainDGV.RowTemplate.Height = 24;
            this.mainDGV.Size = new System.Drawing.Size(747, 349);
            this.mainDGV.TabIndex = 0;
            this.mainDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainDGV_CellContentClick);
            // 
            // col_id
            // 
            this.col_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_id.DataPropertyName = "id";
            this.col_id.HeaderText = "ID";
            this.col_id.Name = "col_id";
            this.col_id.ReadOnly = true;
            this.col_id.Visible = false;
            // 
            // col_name
            // 
            this.col_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_name.DataPropertyName = "name";
            this.col_name.HeaderText = "姓名";
            this.col_name.Name = "col_name";
            this.col_name.ReadOnly = true;
            this.col_name.Width = 54;
            // 
            // col_birth
            // 
            this.col_birth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_birth.DataPropertyName = "birth";
            this.col_birth.HeaderText = "年齡";
            this.col_birth.Name = "col_birth";
            this.col_birth.ReadOnly = true;
            this.col_birth.Width = 54;
            // 
            // col_male
            // 
            this.col_male.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_male.HeaderText = "性別";
            this.col_male.Name = "col_male";
            this.col_male.ReadOnly = true;
            this.col_male.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_male.Width = 54;
            // 
            // col_race_group
            // 
            this.col_race_group.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_race_group.HeaderText = "比賽組別";
            this.col_race_group.Name = "col_race_group";
            this.col_race_group.ReadOnly = true;
            this.col_race_group.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_race_group.Width = 78;
            // 
            // col_tag
            // 
            this.col_tag.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_tag.DataPropertyName = "tag_id";
            this.col_tag.HeaderText = "晶片ID";
            this.col_tag.Name = "col_tag";
            this.col_tag.ReadOnly = true;
            this.col_tag.Width = 66;
            // 
            // col_race_id
            // 
            this.col_race_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_race_id.DataPropertyName = "race_id";
            this.col_race_id.HeaderText = "號碼布";
            this.col_race_id.Name = "col_race_id";
            this.col_race_id.ReadOnly = true;
            this.col_race_id.Width = 66;
            // 
            // col_edit
            // 
            this.col_edit.HeaderText = "編輯";
            this.col_edit.Name = "col_edit";
            this.col_edit.ReadOnly = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(120, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "號碼布搜尋";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(355, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "以晶片搜尋";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(249, 13);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 4;
            // 
            // ParticipantsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 411);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.mainDGV);
            this.Name = "ParticipantsView";
            this.Text = "參賽選手檢視";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ParticipantsView_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.mainDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mainDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_birth;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_male;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_race_group;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tag;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_race_id;
        private System.Windows.Forms.DataGridViewButtonColumn col_edit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
    }
}