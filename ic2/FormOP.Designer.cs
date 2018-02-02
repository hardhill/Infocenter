namespace ic2
{
    partial class FormOP
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlEdit = new System.Windows.Forms.Panel();
            this.dtpBday = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOt = new System.Windows.Forms.TextBox();
            this.txtIm = new System.Windows.Forms.TextBox();
            this.txtFa = new System.Windows.Forms.TextBox();
            this.txtWinlogin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bSaveUser = new System.Windows.Forms.Button();
            this.bAddUser = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.winloginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.faDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.winloginDataGridViewTextBoxColumn,
            this.faDataGridViewTextBoxColumn,
            this.imDataGridViewTextBoxColumn,
            this.otDataGridViewTextBoxColumn,
            this.bdayDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.personBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(554, 193);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // pnlEdit
            // 
            this.pnlEdit.Controls.Add(this.bDelete);
            this.pnlEdit.Controls.Add(this.dtpBday);
            this.pnlEdit.Controls.Add(this.label3);
            this.pnlEdit.Controls.Add(this.txtOt);
            this.pnlEdit.Controls.Add(this.txtIm);
            this.pnlEdit.Controls.Add(this.txtFa);
            this.pnlEdit.Controls.Add(this.txtWinlogin);
            this.pnlEdit.Controls.Add(this.label2);
            this.pnlEdit.Controls.Add(this.label1);
            this.pnlEdit.Controls.Add(this.bSaveUser);
            this.pnlEdit.Controls.Add(this.bAddUser);
            this.pnlEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEdit.Location = new System.Drawing.Point(0, 193);
            this.pnlEdit.Name = "pnlEdit";
            this.pnlEdit.Size = new System.Drawing.Size(554, 138);
            this.pnlEdit.TabIndex = 1;
            // 
            // dtpBday
            // 
            this.dtpBday.CustomFormat = "yyyy-MM-dd";
            this.dtpBday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBday.Location = new System.Drawing.Point(204, 72);
            this.dtpBday.Name = "dtpBday";
            this.dtpBday.Size = new System.Drawing.Size(100, 20);
            this.dtpBday.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Дата рождения";
            // 
            // txtOt
            // 
            this.txtOt.Location = new System.Drawing.Point(310, 41);
            this.txtOt.Name = "txtOt";
            this.txtOt.Size = new System.Drawing.Size(128, 20);
            this.txtOt.TabIndex = 4;
            // 
            // txtIm
            // 
            this.txtIm.Location = new System.Drawing.Point(204, 41);
            this.txtIm.Name = "txtIm";
            this.txtIm.Size = new System.Drawing.Size(100, 20);
            this.txtIm.TabIndex = 3;
            // 
            // txtFa
            // 
            this.txtFa.Location = new System.Drawing.Point(70, 41);
            this.txtFa.Name = "txtFa";
            this.txtFa.Size = new System.Drawing.Size(128, 20);
            this.txtFa.TabIndex = 2;
            // 
            // txtWinlogin
            // 
            this.txtWinlogin.Location = new System.Drawing.Point(70, 12);
            this.txtWinlogin.Name = "txtWinlogin";
            this.txtWinlogin.Size = new System.Drawing.Size(128, 20);
            this.txtWinlogin.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ф.И.О.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Логин";
            // 
            // bSaveUser
            // 
            this.bSaveUser.Location = new System.Drawing.Point(420, 103);
            this.bSaveUser.Name = "bSaveUser";
            this.bSaveUser.Size = new System.Drawing.Size(75, 23);
            this.bSaveUser.TabIndex = 7;
            this.bSaveUser.Text = "Сохранить";
            this.bSaveUser.UseVisualStyleBackColor = true;
            this.bSaveUser.Click += new System.EventHandler(this.bSaveUser_Click);
            // 
            // bAddUser
            // 
            this.bAddUser.Location = new System.Drawing.Point(339, 103);
            this.bAddUser.Name = "bAddUser";
            this.bAddUser.Size = new System.Drawing.Size(75, 23);
            this.bAddUser.TabIndex = 6;
            this.bAddUser.Text = "Добавить";
            this.bAddUser.UseVisualStyleBackColor = true;
            this.bAddUser.Click += new System.EventHandler(this.bAddUser_Click);
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(501, 104);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(41, 21);
            this.bDelete.TabIndex = 8;
            this.bDelete.Text = "DEL";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // winloginDataGridViewTextBoxColumn
            // 
            this.winloginDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.winloginDataGridViewTextBoxColumn.DataPropertyName = "Winlogin";
            this.winloginDataGridViewTextBoxColumn.HeaderText = "Winlogin";
            this.winloginDataGridViewTextBoxColumn.Name = "winloginDataGridViewTextBoxColumn";
            this.winloginDataGridViewTextBoxColumn.ReadOnly = true;
            this.winloginDataGridViewTextBoxColumn.Width = 73;
            // 
            // faDataGridViewTextBoxColumn
            // 
            this.faDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.faDataGridViewTextBoxColumn.DataPropertyName = "Fa";
            this.faDataGridViewTextBoxColumn.HeaderText = "Fa";
            this.faDataGridViewTextBoxColumn.MinimumWidth = 40;
            this.faDataGridViewTextBoxColumn.Name = "faDataGridViewTextBoxColumn";
            this.faDataGridViewTextBoxColumn.ReadOnly = true;
            this.faDataGridViewTextBoxColumn.Width = 44;
            // 
            // imDataGridViewTextBoxColumn
            // 
            this.imDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.imDataGridViewTextBoxColumn.DataPropertyName = "Im";
            this.imDataGridViewTextBoxColumn.HeaderText = "Im";
            this.imDataGridViewTextBoxColumn.Name = "imDataGridViewTextBoxColumn";
            this.imDataGridViewTextBoxColumn.ReadOnly = true;
            this.imDataGridViewTextBoxColumn.Width = 43;
            // 
            // otDataGridViewTextBoxColumn
            // 
            this.otDataGridViewTextBoxColumn.DataPropertyName = "Ot";
            this.otDataGridViewTextBoxColumn.HeaderText = "Ot";
            this.otDataGridViewTextBoxColumn.Name = "otDataGridViewTextBoxColumn";
            this.otDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bdayDataGridViewTextBoxColumn
            // 
            this.bdayDataGridViewTextBoxColumn.DataPropertyName = "Bday";
            this.bdayDataGridViewTextBoxColumn.HeaderText = "Bday";
            this.bdayDataGridViewTextBoxColumn.Name = "bdayDataGridViewTextBoxColumn";
            this.bdayDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // personBindingSource
            // 
            this.personBindingSource.AllowNew = false;
            this.personBindingSource.DataSource = typeof(ic2.Models.Person);
            this.personBindingSource.PositionChanged += new System.EventHandler(this.personBindingSource_PositionChanged);
            // 
            // FormOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 331);
            this.Controls.Add(this.pnlEdit);
            this.Controls.Add(this.dataGridView1);
            this.MaximumSize = new System.Drawing.Size(640, 370);
            this.MinimumSize = new System.Drawing.Size(570, 320);
            this.Name = "FormOP";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Наши люди";
            this.Load += new System.EventHandler(this.FormOP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlEdit.ResumeLayout(false);
            this.pnlEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel pnlEdit;
        private System.Windows.Forms.TextBox txtOt;
        private System.Windows.Forms.TextBox txtIm;
        private System.Windows.Forms.TextBox txtFa;
        private System.Windows.Forms.TextBox txtWinlogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bSaveUser;
        private System.Windows.Forms.Button bAddUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn winloginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn faDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn otDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bdayDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource personBindingSource;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.DateTimePicker dtpBday;
    }
}