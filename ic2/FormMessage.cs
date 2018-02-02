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

namespace ic2
{
    public partial class FormMessage : Form
    {
        private MyClient myClient;

        public FormMessage()
        {
            InitializeComponent();
            myClient = new MyClient("ws://127.0.0.1:3000", "");
            myClient.OnErrorClient += MyClient_OnErrorClient;
            myClient.OnMessageRecievedClient += MyClient_OnMessageRecievedClient;
            myClient.StartClient();
        }

        private void MyClient_OnMessageRecievedClient(object sender, WebSocket4Net.MessageReceivedEventArgs e)
        {
            string value = e.Message;
            Console.WriteLine(value);
        }

        private void MyClient_OnErrorClient(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            Console.WriteLine(e.Exception.Message);
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
            //
        }

        private void FormMessage_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(myClient!=null)myClient.StopClient();
        }
    }
}
