using System;
using System.Windows.Forms;

namespace ic2
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
            this.components = new System.ComponentModel.Container();
            this.pnlContact = new System.Windows.Forms.Panel();
            this.lstContacts = new System.Windows.Forms.ListBox();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.listContacts1 = new ic2.ListContacts();
            this.pnlFindCont = new System.Windows.Forms.Panel();
            this.mnuSpecial = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuChangeUser = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.bGetContacts = new System.Windows.Forms.Button();
            this.pnlMessages = new System.Windows.Forms.Panel();
            this.lstDialog = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblContact = new System.Windows.Forms.Label();
            this.bSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.bMenu1 = new System.Windows.Forms.Button();
            this.pnlContact.SuspendLayout();
            this.pnlFindCont.SuspendLayout();
            this.mnuSpecial.SuspendLayout();
            this.pnlMessages.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContact
            // 
            this.pnlContact.Controls.Add(this.lstContacts);
            this.pnlContact.Controls.Add(this.elementHost1);
            this.pnlContact.Controls.Add(this.pnlFindCont);
            this.pnlContact.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlContact.Location = new System.Drawing.Point(0, 0);
            this.pnlContact.Name = "pnlContact";
            this.pnlContact.Size = new System.Drawing.Size(261, 370);
            this.pnlContact.TabIndex = 0;
            // 
            // lstContacts
            // 
            this.lstContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstContacts.FormattingEnabled = true;
            this.lstContacts.Location = new System.Drawing.Point(0, 47);
            this.lstContacts.Name = "lstContacts";
            this.lstContacts.Size = new System.Drawing.Size(261, 223);
            this.lstContacts.TabIndex = 1;
            this.lstContacts.SelectedIndexChanged += new System.EventHandler(this.lstContacts_SelectedIndexChanged);
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.elementHost1.Location = new System.Drawing.Point(0, 270);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(261, 100);
            this.elementHost1.TabIndex = 3;
            this.elementHost1.Child = this.listContacts1;
            // 
            // pnlFindCont
            // 
            this.pnlFindCont.BackColor = System.Drawing.SystemColors.Control;
            this.pnlFindCont.ContextMenuStrip = this.mnuSpecial;
            this.pnlFindCont.Controls.Add(this.label2);
            this.pnlFindCont.Controls.Add(this.bGetContacts);
            this.pnlFindCont.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFindCont.Location = new System.Drawing.Point(0, 0);
            this.pnlFindCont.Name = "pnlFindCont";
            this.pnlFindCont.Size = new System.Drawing.Size(261, 47);
            this.pnlFindCont.TabIndex = 0;
            // 
            // mnuSpecial
            // 
            this.mnuSpecial.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuChangeUser});
            this.mnuSpecial.Name = "mnuSpecial";
            this.mnuSpecial.Size = new System.Drawing.Size(223, 26);
            // 
            // mnuChangeUser
            // 
            this.mnuChangeUser.Name = "mnuChangeUser";
            this.mnuChangeUser.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.F12)));
            this.mnuChangeUser.Size = new System.Drawing.Size(222, 22);
            this.mnuChangeUser.Text = "UserChange";
            this.mnuChangeUser.Visible = false;
            this.mnuChangeUser.Click += new System.EventHandler(this.mnuChangeUser_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Список контактов on-line";
            // 
            // bGetContacts
            // 
            this.bGetContacts.Location = new System.Drawing.Point(175, 12);
            this.bGetContacts.Name = "bGetContacts";
            this.bGetContacts.Size = new System.Drawing.Size(75, 23);
            this.bGetContacts.TabIndex = 1;
            this.bGetContacts.Text = "Обновить";
            this.bGetContacts.UseVisualStyleBackColor = true;
            this.bGetContacts.Click += new System.EventHandler(this.bGetContacts_Click);
            // 
            // pnlMessages
            // 
            this.pnlMessages.Controls.Add(this.lstDialog);
            this.pnlMessages.Controls.Add(this.panel2);
            this.pnlMessages.Controls.Add(this.panel1);
            this.pnlMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMessages.Location = new System.Drawing.Point(261, 0);
            this.pnlMessages.Name = "pnlMessages";
            this.pnlMessages.Size = new System.Drawing.Size(336, 370);
            this.pnlMessages.TabIndex = 1;
            // 
            // lstDialog
            // 
            this.lstDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDialog.FormattingEnabled = true;
            this.lstDialog.Location = new System.Drawing.Point(0, 47);
            this.lstDialog.Name = "lstDialog";
            this.lstDialog.Size = new System.Drawing.Size(336, 259);
            this.lstDialog.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblContact);
            this.panel2.Controls.Add(this.bSend);
            this.panel2.Controls.Add(this.txtMessage);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 306);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(336, 64);
            this.panel2.TabIndex = 1;
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Location = new System.Drawing.Point(18, 12);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(78, 13);
            this.lblContact.TabIndex = 2;
            this.lblContact.Text = "Адресат: (нет)";
            // 
            // bSend
            // 
            this.bSend.Location = new System.Drawing.Point(298, 32);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(31, 20);
            this.bSend.TabIndex = 1;
            this.bSend.Text = ">>";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // txtMessage
            // 
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.Location = new System.Drawing.Point(18, 32);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(271, 20);
            this.txtMessage.TabIndex = 0;
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 47);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Диалог";
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.bMenu1);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlMenu.Location = new System.Drawing.Point(597, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(133, 370);
            this.pnlMenu.TabIndex = 2;
            // 
            // bMenu1
            // 
            this.bMenu1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bMenu1.FlatAppearance.BorderSize = 0;
            this.bMenu1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bMenu1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMenu1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bMenu1.Location = new System.Drawing.Point(0, 0);
            this.bMenu1.Name = "bMenu1";
            this.bMenu1.Size = new System.Drawing.Size(133, 47);
            this.bMenu1.TabIndex = 3;
            this.bMenu1.Text = "Инфоцентр";
            this.bMenu1.UseVisualStyleBackColor = true;
            // 
            // FormMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 370);
            this.Controls.Add(this.pnlMessages);
            this.Controls.Add(this.pnlContact);
            this.Controls.Add(this.pnlMenu);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(746, 300);
            this.Name = "FormMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сообщения (нет соединения)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMessage_FormClosing_1);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMessage_FormClosed);
            this.Load += new System.EventHandler(this.FormMessage_Load);
            this.pnlContact.ResumeLayout(false);
            this.pnlFindCont.ResumeLayout(false);
            this.pnlFindCont.PerformLayout();
            this.mnuSpecial.ResumeLayout(false);
            this.pnlMessages.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        


        #endregion

        private System.Windows.Forms.Panel pnlContact;
        private System.Windows.Forms.Panel pnlFindCont;
        private System.Windows.Forms.Panel pnlMessages;
        public System.Windows.Forms.ListBox lstContacts;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.Button bGetContacts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip mnuSpecial;
        private System.Windows.Forms.ToolStripMenuItem mnuChangeUser;
        public ListBox lstDialog;
        public Label lblContact;
        private Panel pnlMenu;
        private Button bMenu1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private ListContacts listContacts1;
    }
}