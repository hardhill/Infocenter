namespace ChatServ
{
    partial class frmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Memo1 = new System.Windows.Forms.TextBox();
            this.bStart = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Memo1
            // 
            this.Memo1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Memo1.Location = new System.Drawing.Point(0, 53);
            this.Memo1.Margin = new System.Windows.Forms.Padding(5);
            this.Memo1.Multiline = true;
            this.Memo1.Name = "Memo1";
            this.Memo1.ReadOnly = true;
            this.Memo1.Size = new System.Drawing.Size(420, 248);
            this.Memo1.TabIndex = 0;
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(12, 22);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 1;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bStop
            // 
            this.bStop.Location = new System.Drawing.Point(333, 22);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(75, 23);
            this.bStop.TabIndex = 2;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 301);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.Memo1);
            this.Name = "frmMain";
            this.Text = "Chat server 1.0";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Memo1;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bStop;
    }
}

