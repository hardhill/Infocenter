using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using Newtonsoft.Json;
using ic2.Models;
using Microsoft.Win32;
using System.Configuration;
using System.Security.Principal;

namespace ic2
{
    public partial class FormMessage : Form
    {
        
        //текущий пользователь сообщателя
        ContactUser CurrentContactUser;
        SecretForm secretForm;
        FormMain formMain;
        public FormMessage(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
        }

        private void FormMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void FormMessage_Load(object sender, EventArgs e)
        {
            
        }

        private void FormMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void mnuChangeUser_Click(object sender, EventArgs e)
        {
            secretForm = new SecretForm();
            if (secretForm.ShowDialog() == DialogResult.OK)
            {
                formMain.myClient.Winlogin = secretForm.textBox1.Text;
                formMain.myClient.RestartTry();

            }
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                bSend_Click(sender, e);
            }
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            //отправить сообщение
            if (CurrentContactUser.Winlogin != null && txtMessage.Text != "")
            {
                formMain.myClient.SendMessage(CurrentContactUser.Winlogin, txtMessage.Text);
                txtMessage.Text = "";
            }
        }

        private void bGetContacts_Click(object sender, EventArgs e)
        {
            //запросить контакты принудительно
            formMain.myClient.GetClients();
        }

        private void lstContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //выбор клиента в списке
            var idx = lstContacts.SelectedIndex;
            lblContact.Text = "Адресат: " + lstContacts.Items[idx].ToString();
            CurrentContactUser = lstContacts.Items[idx] as ContactUser;
            //переключение на диалог
            lstDialog.Items.Clear();
            formMain.myClient.GetDialog();
        }

        private void FormMessage_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
    }
}
