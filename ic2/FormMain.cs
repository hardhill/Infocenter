using ic2.Models;
using Microsoft.Win32;
using Newtonsoft.Json;
using SuperSocket.ClientEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocket4Net;

namespace ic2
{
    public partial class FormMain : Form
    {
        
        
        private bool allowshowdisplay = true;


        

        public FormMessage formMessage;
        public MyClient myClient;
        public ContactUser CurrentContactUser;

       // public IMessageFilter messageFilter { get; private set; }

        public FormMain()
        {
            SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;
            InitializeComponent();

            Visible = true;
            formMessage = new FormMessage(this);
            

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

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(allowshowdisplay ? value : allowshowdisplay);
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                //notifyIcon1.BalloonTipText = "Для активации программы нажмите правой клавишей мыши на иконке";
                //notifyIcon1.ShowBalloonTip(300);
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        public void SetBalloonTip(string msg)
        {
            //notifyIcon1.Icon = SystemIcons.Exclamation;
            notifyIcon1.BalloonTipTitle = "Вам сообщение";
            notifyIcon1.BalloonTipText = msg;
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(3000);

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.allowshowdisplay = true;
                this.Visible = !this.Visible;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                notifyIcon1.Visible = true;
                //notifyIcon1.BalloonTipText = "Для активации программы нажмите правой клавишей мыши на иконке";
                //notifyIcon1.ShowBalloonTip(300);
                this.Hide();
            }
        }

        private void mnuCloseProgramm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this, Control.MousePosition); // or any other overload
            }
            if(e.Button == MouseButtons.Left)
            {
                if (formMessage == null || formMessage.IsDisposed)
                {
                    formMessage = new FormMessage(this);
                    
                }
                formMessage.Show();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            web.IsWebBrowserContextMenuEnabled = false;
            string server = ConfigurationManager.ConnectionStrings["Server"].ConnectionString;
            myClient = new MyClient(server, "");
            CurrentContactUser = new ContactUser();
            myClient.OnErrorClient += MyClient_OnErrorClient;
            myClient.OnMessageRecievedClient += MyClient_OnMessageRecievedClient;
            myClient.OnChangeContactList += MyClient_OnChangeContactList;
            myClient.OnChangeDialogList += MyClient_OnChangeDialogList;
            myClient.OnOpenedClient += MyClient_OnOpenedClient;
            try
            {
                var name = WindowsIdentity.GetCurrent().Name;
                myClient.Winlogin = name.Substring(name.IndexOf('\\') + 1);

                myClient.StartClient();
            }
            catch (Exception)
            {

            }
        }

        private void MyClient_OnOpenedClient(object sender, EventArgs e)
        {
            if (formMessage.IsHandleCreated)
            {
                formMessage.BeginInvoke((MethodInvoker)(delegate
                {
                    formMessage.Text = myClient.Winlogin;
                }));
            }
        }

        private void MyClient_OnChangeDialogList(List<Dialoge> dialoges)
        {
            //
            if (formMessage.IsHandleCreated)
            {
                if (dialoges.Count > 0)
                {
                    formMessage.lstDialog.BeginInvoke((MethodInvoker)(delegate
                    {
                        Dialoge dlg = dialoges[dialoges.Count - 1];
                        formMessage.lstDialog.Items.Add(dlg);
                    }));
                }
            }
        }

        private void MyClient_OnChangeContactList(List<ContactUser> contacts)
        {
            //изменение списка контактов
            if (formMessage.IsHandleCreated)
            {
                formMessage.lstContacts.BeginInvoke((MethodInvoker)(delegate
                {
                    if (myClient.Contactuser != null)
                    {
                        formMessage.Text = String.Format("{0} {1} {2}", myClient.Contactuser.Fa, myClient.Contactuser.Im, myClient.Contactuser.Ot);
                        formMessage.lstContacts.Items.Clear();
                        foreach (var cont in contacts)
                        {
                            formMessage.lstContacts.Items.Add(cont);
                        }
                        if (formMessage.lstContacts.Items.Count > 0)
                        {
                            formMessage.lstContacts.SelectedIndex = 0;
                        }
                        else
                        {
                            formMessage.lblContact.Text = "Адресат: (нет)";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы не прошли авторизацию.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }));
            }
        }

        private void MyClient_OnMessageRecievedClient(object sender, MessageReceivedEventArgs e)
        {
            //получение новых сообщений
            if (this.IsHandleCreated)
            {
                Comm comm_resp = new Comm()
                {
                    CommName = JsonConvert.DeserializeObject<Comm>(e.Message).CommName,
                    Body = JsonConvert.DeserializeObject<Comm>(e.Message).Body
                };
                if (comm_resp.CommName == "MSG")
                {
                    MessageSend msg = JsonConvert.DeserializeObject<MessageSend>(comm_resp.Body.ToString());
                    if (msg.Sender != myClient.Winlogin)
                    {
                        this.SetBalloonTip("Вам пришло сообщение\r\n"+"От:"+msg.Sender);
                    }
                }

            }
        }

        private void MyClient_OnErrorClient(object sender, ErrorEventArgs e)
        {
           //
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
           //
           
        }

        private static void RunOurPeople()
        {
            FormOP formOP = new FormOP();
            formOP.Show();
        }

        private void editContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunOurPeople();
        }
    }

    
}
