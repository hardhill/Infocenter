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

        ContactUser contactUser;

        public frmClient()
        {
           
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
            InitializeComponent();
            string server = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            myClient = new MyClient(server, "");
            contactUser = new ContactUser();
            myClient.OnErrorClient += MyClient_OnErrorClient;
            myClient.OnMessageRecievedClient += MyClient_OnMessageRecievedClient;
            myClient.OnChangeContactList += MyClient_OnChangeContactList;
            myClient.OnChangeDialogList += MyClient_OnChangeDialogList;

            if (myClient.SystemLogined())
            {

                myClient.StartClient();
            }
            else
                myClient.Free();
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

        private void MyClient_OnChangeContactList(List<ContactUser> contacts)
        {
            this.lstContacts.BeginInvoke((MethodInvoker)(delegate {


                lstContacts.Items.Clear();
                foreach (var cont in contacts)
                {
                    lstContacts.Items.Add(cont);
                }

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
           contactUser = lstContacts.Items[idx] as ContactUser;
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            //отправить сообщение
            if (contactUser != null)
            {
                myClient.SendMessage(contactUser.Winlogin,  txtMessage.Text);
                txtMessage.Text = "";
            }
        }
    }
}
