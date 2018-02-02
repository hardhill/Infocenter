﻿namespace ic2
{
    partial class FormMessage
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
            this.pnlMessages = new System.Windows.Forms.Panel();
            this.pnlFindCont = new System.Windows.Forms.Panel();
            this.txtFindCont = new System.Windows.Forms.TextBox();
            this.lstContacts = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstDialog = new System.Windows.Forms.ListBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.pnlContact.SuspendLayout();
            this.pnlMessages.SuspendLayout();
            this.pnlFindCont.SuspendLayout();
            this.panel2.SuspendLayout();
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
            // pnlFindCont
            // 
            this.pnlFindCont.Controls.Add(this.txtFindCont);
            this.pnlFindCont.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFindCont.Location = new System.Drawing.Point(0, 0);
            this.pnlFindCont.Name = "pnlFindCont";
            this.pnlFindCont.Size = new System.Drawing.Size(300, 47);
            this.pnlFindCont.TabIndex = 0;
            // 
            // txtFindCont
            // 
            this.txtFindCont.Location = new System.Drawing.Point(13, 15);
            this.txtFindCont.Name = "txtFindCont";
            this.txtFindCont.Size = new System.Drawing.Size(271, 20);
            this.txtFindCont.TabIndex = 0;
            // 
            // lstContacts
            // 
            this.lstContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstContacts.FormattingEnabled = true;
            this.lstContacts.Location = new System.Drawing.Point(0, 47);
            this.lstContacts.Name = "lstContacts";
            this.lstContacts.Size = new System.Drawing.Size(300, 313);
            this.lstContacts.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 47);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtMessage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 307);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(342, 53);
            this.panel2.TabIndex = 1;
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
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(68, 19);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(222, 20);
            this.txtMessage.TabIndex = 0;
            // 
            // FormMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 360);
            this.Controls.Add(this.pnlMessages);
            this.Controls.Add(this.pnlContact);
            this.MaximumSize = new System.Drawing.Size(720, 600);
            this.MinimumSize = new System.Drawing.Size(520, 300);
            this.Name = "FormMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сообщения";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMessage_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMessage_FormClosed);
            this.Load += new System.EventHandler(this.FormMessage_Load);
            this.pnlContact.ResumeLayout(false);
            this.pnlMessages.ResumeLayout(false);
            this.pnlFindCont.ResumeLayout(false);
            this.pnlFindCont.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Panel pnlContact;
        private System.Windows.Forms.Panel pnlFindCont;
        private System.Windows.Forms.TextBox txtFindCont;
        private System.Windows.Forms.Panel pnlMessages;
        private System.Windows.Forms.ListBox lstContacts;
        private System.Windows.Forms.ListBox lstDialog;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Panel panel1;
    }
}