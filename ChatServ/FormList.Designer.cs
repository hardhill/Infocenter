namespace ChatServ
{
    partial class FormList
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
            this.lstClients = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstClients
            // 
            this.lstClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstClients.FormattingEnabled = true;
            this.lstClients.Location = new System.Drawing.Point(0, 0);
            this.lstClients.Name = "lstClients";
            this.lstClients.Size = new System.Drawing.Size(184, 261);
            this.lstClients.TabIndex = 0;
            // 
            // FormList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 261);
            this.Controls.Add(this.lstClients);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 640);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 220);
            this.Name = "FormList";
            this.Text = "Clients";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox lstClients;
    }
}