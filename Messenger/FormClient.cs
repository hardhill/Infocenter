using Messenger.Models;
using Microsoft.Win32;
using SuperSocket.ClientEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocket4Net;

namespace Messenger
{
    public partial class frmClient : Form
    {
        private MyClient myClient;

        ContactUser CurrentContactUser;

        public frmClient()
        {
           
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
            InitializeComponent();
            string server = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            
            myClient = new MyClient(server, "");
            CurrentContactUser = new ContactUser();
            myClient.OnErrorClient += MyClient_OnErrorClient;
            myClient.OnMessageRecievedClient += MyClient_OnMessageRecievedClient;
            myClient.OnChangeContactList += MyClient_OnChangeContactList;
            myClient.OnChangeDialogList += MyClient_OnChangeDialogList;
            myClient.OnOpenedClient += MyClient_OnOpenedClient;

            
            //myClient.StartClient();
            
        }

        private void MyClient_OnOpenedClient(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)(delegate{
                this.Text = myClient.Winlogin;
            }));
        }

        private void MyClient_OnChangeDialogList(List<Dialoge> dialoges)
        {
            if (dialoges.Count > 0)
            {
                this.lstDialog.BeginInvoke((MethodInvoker)(delegate
                {
                    Dialoge dlg = dialoges[dialoges.Count - 1];
                    lstDialog.Items.Add(dlg);
                }));
            }
        }

        //изменение списка контактов клиента
        private void MyClient_OnChangeContactList(List<ContactUser> contacts)
        {
            this.lstContacts.BeginInvoke((MethodInvoker)(delegate {

                this.Text = String.Format("{0} {1} {2}", myClient.Contactuser.Fa, myClient.Contactuser.Im, myClient.Contactuser.Ot);
                lstContacts.Items.Clear();
                foreach (var cont in contacts)
                {
                    lstContacts.Items.Add(cont);
                }
                lstContacts.SelectedIndex = lstContacts.Items.Count>0?0:-1;

            }));
            
            
        }

        private void MyClient_OnMessageRecievedClient(object sender, MessageReceivedEventArgs e)
        {
           // 
        }

        private void MyClient_OnErrorClient(object sender, ErrorEventArgs e)
        {
            //
        }

        private void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            switch (e.Reason)
            {
                case SessionSwitchReason.SessionLock:
                    myClient.StartClient();
                    break;
                case SessionSwitchReason.SessionUnlock:
                    myClient.StopClient();
                    break;
                case SessionSwitchReason.SessionLogon:
                    break;
                case SessionSwitchReason.SessionLogoff:
                    break;
                default:
                    break;
            }
        }

        private void lstContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //выбор клиента в списке
           var idx = lstContacts.SelectedIndex;
           lblContact.Text = lstContacts.Items[idx].ToString();
           CurrentContactUser = lstContacts.Items[idx] as ContactUser;
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            //отправить сообщение
            if (CurrentContactUser.Winlogin != null&&txtMessage.Text!="")
            {
                myClient.SendMessage(CurrentContactUser.Winlogin,  txtMessage.Text);
                txtMessage.Text = "";
            }
        }

        private void bGetContacts_Click(object sender, EventArgs e)
        {
            //запросить контакты принудительно
            myClient.GetClients();
        }

        private void txtFindCont_TextChanged(object sender, EventArgs e)
        {
            //поиск в контактах
        }

        //временно
        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            myClient.Winlogin = cb.Text;
            myClient.StartClient();
        }

        private void frmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            myClient.StopClient();
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                bSend_Click(sender, e);
            }
        }
    }
}
