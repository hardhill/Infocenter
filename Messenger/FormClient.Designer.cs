namespace Messenger
{
    partial class frmClient
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
            this.pnlContact = new System.Windows.Forms.Panel();
            this.lstContacts = new System.Windows.Forms.ListBox();
            this.pnlFindCont = new System.Windows.Forms.Panel();
            this.cb = new System.Windows.Forms.ComboBox();
            this.bGetContacts = new System.Windows.Forms.Button();
            this.txtFindCont = new System.Windows.Forms.TextBox();
            this.pnlMessages = new System.Windows.Forms.Panel();
            this.lstDialog = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblContact = new System.Windows.Forms.Label();
            this.pnlContact.SuspendLayout();
            this.pnlFindCont.SuspendLayout();
            this.pnlMessages.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContact
            // 
            this.pnlContact.Controls.Add(this.lstContacts);
            this.pnlContact.Controls.Add(this.pnlFindCont);
            this.pnlContact.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlContact.Location = new System.Drawing.Point(0, 0);
            this.pnlContact.Name = "pnlContact";
            this.pnlContact.Size = new System.Drawing.Size(300, 360);
            this.pnlContact.TabIndex = 0;
            // 
            // lstContacts
            // 
            this.lstContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstContacts.FormattingEnabled = true;
            this.lstContacts.Location = new System.Drawing.Point(0, 80);
            this.lstContacts.Name = "lstContacts";
            this.lstContacts.Size = new System.Drawing.Size(300, 280);
            this.lstContacts.TabIndex = 1;
            this.lstContacts.SelectedIndexChanged += new System.EventHandler(this.lstContacts_SelectedIndexChanged);
            // 
            // pnlFindCont
            // 
            this.pnlFindCont.Controls.Add(this.cb);
            this.pnlFindCont.Controls.Add(this.bGetContacts);
            this.pnlFindCont.Controls.Add(this.txtFindCont);
            this.pnlFindCont.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFindCont.Location = new System.Drawing.Point(0, 0);
            this.pnlFindCont.Name = "pnlFindCont";
            this.pnlFindCont.Size = new System.Drawing.Size(300, 80);
            this.pnlFindCont.TabIndex = 0;
            // 
            // cb
            // 
            this.cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb.FormattingEnabled = true;
            this.cb.Items.AddRange(new object[] {
            "Waclaw",
            "Test1",
            "Test2"});
            this.cb.Location = new System.Drawing.Point(104, 15);
            this.cb.Name = "cb";
            this.cb.Size = new System.Drawing.Size(179, 21);
            this.cb.TabIndex = 2;
            this.cb.SelectedIndexChanged += new System.EventHandler(this.cb_SelectedIndexChanged);
            // 
            // bGetContacts
            // 
            this.bGetContacts.Location = new System.Drawing.Point(12, 13);
            this.bGetContacts.Name = "bGetContacts";
            this.bGetContacts.Size = new System.Drawing.Size(75, 23);
            this.bGetContacts.TabIndex = 1;
            this.bGetContacts.Text = "Контакты";
            this.bGetContacts.UseVisualStyleBackColor = true;
            this.bGetContacts.Click += new System.EventHandler(this.bGetContacts_Click);
            // 
            // txtFindCont
            // 
            this.txtFindCont.Location = new System.Drawing.Point(12, 47);
            this.txtFindCont.Name = "txtFindCont";
            this.txtFindCont.Size = new System.Drawing.Size(271, 20);
            this.txtFindCont.TabIndex = 0;
            this.txtFindCont.TextChanged += new System.EventHandler(this.txtFindCont_TextChanged);
            // 
            // pnlMessages
            // 
            this.pnlMessages.Controls.Add(this.lstDialog);
            this.pnlMessages.Controls.Add(this.panel2);
            this.pnlMessages.Controls.Add(this.panel1);
            this.pnlMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMessages.Location = new System.Drawing.Point(300, 0);
            this.pnlMessages.Name = "pnlMessages";
            this.pnlMessages.Size = new System.Drawing.Size(342, 360);
            this.pnlMessages.TabIndex = 1;
            // 
            // lstDialog
            // 
            this.lstDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDialog.FormattingEnabled = true;
            this.lstDialog.Location = new System.Drawing.Point(0, 47);
            this.lstDialog.Name = "lstDialog";
            this.lstDialog.Size = new System.Drawing.Size(342, 260);
            this.lstDialog.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bSend);
            this.panel2.Controls.Add(this.txtMessage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 307);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(342, 53);
            this.panel2.TabIndex = 1;
            // 
            // bSend
            // 
            this.bSend.Location = new System.Drawing.Point(298, 20);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(31, 18);
            this.bSend.TabIndex = 1;
            this.bSend.Text = ">>";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Location = new System.Drawing.Point(19, 19);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(271, 20);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblContact);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 47);
            this.panel1.TabIndex = 0;
            // 
            // lblContact
            // 
            this.lblContact.Location = new System.Drawing.Point(16, 18);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(314, 17);
            this.lblContact.TabIndex = 0;
            // 
            // frmClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 360);
            this.Controls.Add(this.pnlMessages);
            this.Controls.Add(this.pnlContact);
            this.MaximumSize = new System.Drawing.Size(720, 600);
            this.MinimumSize = new System.Drawing.Size(520, 300);
            this.Name = "frmClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сообщения";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClient_FormClosing);
            this.pnlContact.ResumeLayout(false);
            this.pnlFindCont.ResumeLayout(false);
            this.pnlFindCont.PerformLayout();
            this.pnlMessages.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Panel pnlContact;
        private System.Windows.Forms.Panel pnlFindCont;
        private System.Windows.Forms.TextBox txtFindCont;
        private System.Windows.Forms.Panel pnlMessages;
        public System.Windows.Forms.ListBox lstContacts;
        private System.Windows.Forms.ListBox lstDialog;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.Button bGetContacts;
        private System.Windows.Forms.ComboBox cb;
    }
}

