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
        private MyClient myClient;
        //текущий пользователь сообщателя
        ContactUser CurrentContactUser;
        SecretForm secretForm;
        public FormMessage()
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
            if (this.IsHandleCreated)
            {
                this.BeginInvoke((MethodInvoker)(delegate
                {
                    this.Text = myClient.Winlogin;
                }));
            }
            
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

        //событие - изменение списка контактов
        private void MyClient_OnChangeContactList(List<ContactUser> contacts)
        {
            if (this.IsHandleCreated)
            {
                this.lstContacts.BeginInvoke((MethodInvoker)(delegate
                {
                    if (myClient.Contactuser != null)
                    {
                        this.Text = String.Format("{0} {1} {2}", myClient.Contactuser.Fa, myClient.Contactuser.Im, myClient.Contactuser.Ot);
                        lstContacts.Items.Clear();
                        foreach (var cont in contacts)
                        {
                            lstContacts.Items.Add(cont);
                        }
                        lstContacts.SelectedIndex = lstContacts.Items.Count > 0 ? 0 : -1;
                    }
                    else
                    {
                        MessageBox.Show("Вы не прошли авторизацию.", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }));
            }
        }



        //реагируем на события системы
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

        private void MyClient_OnMessageRecievedClient(object sender, WebSocket4Net.MessageReceivedEventArgs e)
        {
            //
        }

       

        private void MyClient_OnErrorClient(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            //MessageBox.Show(e.Exception.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            MyClient_OnOpenedClient(sender, e);
            myClient.GetClients();
        }

        private void FormMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(myClient!=null)myClient.StopClient();
        }

        

       

        private void mnuChangeUser_Click(object sender, EventArgs e)
        {
            secretForm = new SecretForm();
            if (secretForm.ShowDialog() == DialogResult.OK)
            {
                myClient.Winlogin = secretForm.textBox1.Text;
                myClient.RestartTry();

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
                myClient.SendMessage(CurrentContactUser.Winlogin, txtMessage.Text);
                txtMessage.Text = "";
            }
        }

        private void bGetContacts_Click(object sender, EventArgs e)
        {
            //запросить контакты принудительно
            myClient.GetClients();
        }

        private void lstContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //выбор клиента в списке
            var idx = lstContacts.SelectedIndex;
            lblContact.Text = "Адресат: " + lstContacts.Items[idx].ToString();
            CurrentContactUser = lstContacts.Items[idx] as ContactUser;
            //переключение на диалог
            lstDialog.Items.Clear();
            myClient.GetDialog();
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
