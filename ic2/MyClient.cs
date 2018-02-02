using ic2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using WebSocket4Net;

namespace ic2
{
    class MyClient
    {
        public delegate void CloseSocket(object sender,EventArgs e);
        public delegate void DataRecieved(object sender, DataReceivedEventArgs e);
        public delegate void ErrorClient(object sender, SuperSocket.ClientEngine.ErrorEventArgs e);
        public delegate void OpenedClient(object sender, EventArgs e);
        public delegate void MessageRecievedClient(object sender, MessageReceivedEventArgs e);
        public event CloseSocket OnCloseSocket;
        public event DataRecieved OnDataRecieved;
        public event ErrorClient OnErrorClient;


        public event OpenedClient OnOpenedClient;
        public event MessageRecievedClient OnMessageRecievedClient;

        private string url;
        private string protocol;
        private WebSocketVersion version;
        private string _id;

        private WebSocket webSocket;
        private string _username;

        public string UserName { get { return _username; }}

        public MyClient(string uri,string protocol)
        {
            this.url = uri;
            this.protocol = protocol;
            this.version = WebSocketVersion.Rfc6455;

            webSocket = new WebSocket(this.url, this.protocol, this.version);
            webSocket.AutoSendPingInterval = 1000;
            webSocket.Closed += WebSocket_Closed;
            webSocket.DataReceived += WebSocket_DataReceived;
            webSocket.Error += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(WebSocket_Error);
            webSocket.Opened += WebSocket_Opened;
            webSocket.MessageReceived += WebSocket_MessageReceived;
        }

        private void WebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            string value = e.Message;
            ControllerCommandIn(ref value);
            webSocket.Send(value);
            OnMessageRecievedClient?.Invoke(sender,e);
        }

        private void WebSocket_Opened(object sender, EventArgs e)
        {
            OnOpenedClient?.Invoke(sender,e);
        }

        private void WebSocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            OnErrorClient?.Invoke(sender, e);
        }

        internal void SetId(string idSession)
        {
            _id = idSession;
        }

        internal string GetId()
        {
            return _id;
        }

        private void WebSocket_DataReceived(object sender, DataReceivedEventArgs e)
        {
            OnDataRecieved?.Invoke(sender, e);
        }

        private void WebSocket_Closed(object sender, EventArgs e)
        {
            OnCloseSocket?.Invoke(sender, e);
        }

        public void StartClient()
        {
            webSocket.Open();
        }

        public void StopClient()
        {
            webSocket.Close();
        }


        internal bool SystemLogin()
        {
            //логин пользователя
            _username = WindowsIdentity.GetCurrent().Name;
            return (_username != null);
        }

        //процессор приема сообщений
        private void ControllerCommandIn(ref string value)
        {
            Client cli = new Client();
            Comm comm = JsonConvert.DeserializeObject<Comm>(value);
            string commandName = comm.CommName;
            cli = JsonConvert.DeserializeObject<Client>(comm.Body.ToString());

            switch (commandName)
            {
                case "NEWUSER":
                    SetId(cli.IdSession);//установить идентификатор сессии для клиента
                    //отправить инфу для сервера
                    Comm comm_resp = new Comm() { CommName = commandName, Body = new Client() { UserName = this.UserName, IdSession = GetId() } };
                    string json = JsonConvert.SerializeObject(comm_resp);
                    value = json;
                    break;
                default:
                    StopClient();
                    break;
            }
        }


        private class Comm
        {
            public string CommName { get; set; }
            public object Body { get; set; }
        }

        internal void Free()
        {
            webSocket.Dispose();
        }
    }
}
