using Messendger.Models;
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

namespace Messendger
{
    public partial class frmClient : Form
    {
        private MyClient myClient;
        public frmClient()
        {
           
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
            InitializeComponent();
            string server = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            myClient = new MyClient(server, "");
            myClient.OnErrorClient += MyClient_OnErrorClient;
            myClient.OnMessageRecievedClient += MyClient_OnMessageRecievedClient;
            myClient.OnChangeContactList += MyClient_OnChangeContactList;

            if (myClient.SystemLogined())
            {

                myClient.StartClient();
            }
            else
                myClient.Free();
        }

        private void MyClient_OnChangeContactList(List<ContactUser> contacts)
        {
            this.lstContacts.BeginInvoke((MethodInvoker)(delegate {


                lstContacts.Items.Clear();
                foreach (var cont in contacts)
                {
                    lstContacts.Items.Add(String.Format("{0} {1} {2}", cont.Fa, cont.Im, cont.Ot));
                }

            }));
            
            
        }

        private void MyClient_OnMessageRecievedClient(object sender, MessageReceivedEventArgs e)
        {
           // 
        }

        private void MyClient_OnErrorClient(object sender, ErrorEventArgs e)
        {
            throw new NotImplementedException();
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
    }
}
