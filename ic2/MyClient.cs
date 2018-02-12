using ic2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
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
        public delegate void ChangeContactList(List<ContactUser> contacts);
        public event CloseSocket OnCloseSocket;
        public event DataRecieved OnDataRecieved;
        public event ErrorClient OnErrorClient;
        public event OpenedClient OnOpenedClient;
        public event MessageRecievedClient OnMessageRecievedClient;
        public event ChangeContactList OnChangeContactList;

        private string url;
        private string protocol;
        private WebSocketVersion version;
        private string _id;

        private WebSocket webSocket;
        private string _username;
       // private Timer timer1;
        internal bool Active;
        List<ContactUser> contacts = new List<ContactUser>();

        public string UserName { get { return _username; }}

        public MyClient(string uri,string protocol)
        {
            this.url = uri;
            this.protocol = protocol;
            this.version = WebSocketVersion.Rfc6455;

            this.Active = false;
            //this.timer1 = new Timer(new TimerCallback(TickTimer1),null,1000,3000);
            webSocket = new WebSocket(this.url, this.protocol, this.version);
            webSocket.AutoSendPingInterval = 2000;
            
            webSocket.Closed += WebSocket_Closed;
            webSocket.DataReceived += WebSocket_DataReceived;
            webSocket.Error += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(WebSocket_Error);
            webSocket.Opened += WebSocket_Opened;
            webSocket.MessageReceived += WebSocket_MessageReceived;
            
        }

        private void TickTimer1(object state)
        {
            Console.WriteLine(this.webSocket.State);
            if(webSocket.State == WebSocketState.Open)
            {

            }
            if(webSocket.State == WebSocketState.Closed)
            {
                webSocket.Open();
            }
           
        }

        private void WebSocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            string value = e.Message;
            value = ControllerCommandIn(value);
            webSocket.Send(value);
            OnMessageRecievedClient?.Invoke(sender,e);
        }
        //соединение установлено
        private void WebSocket_Opened(object sender, EventArgs e)
        {
            if (webSocket.State == WebSocketState.Open)
            {
                Active = true;
                //
                //timer1.Change(0, Timeout.Infinite);
            }
            OnOpenedClient?.Invoke(sender,e);
        }

        private void WebSocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
            Active = false;
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

            if (webSocket.State == WebSocketState.Closed)
            {
                Active = false;
            }
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


        internal bool SystemLogined()
        {
            //логин пользователя
            var s = WindowsIdentity.GetCurrent().Name;
            var n = s.LastIndexOf('\\');
            _username = s.Substring(n+1);
            return (_username != null);
        }

        //процессор приема сообщений
        private string ControllerCommandIn(string value)
        {
            string returnjson="{}";
            Comm comm = JsonConvert.DeserializeObject<Comm>(value);
            string commandName = comm.CommName;
            

            switch (commandName)
            {
                case "SENDID":
                    Client cli = new Client();
                    cli = JsonConvert.DeserializeObject<Client>(comm.Body.ToString());
                    SetId(cli.IdSession);//установить идентификатор сессии для клиента
                    //отправить инфу для сервера
                    Comm comm_resp = new Comm() { CommName = "NEWUSER", Body = new Client() { UserName = this.UserName, IdSession = GetId() } };
                    string json = JsonConvert.SerializeObject(comm_resp);
                    returnjson = json;
                    break;
                case "NEWUSER":
                    contacts = JsonConvert.DeserializeObject<List<ContactUser>>(comm.Body.ToString());
                    //инициировать событие
                    OnChangeContactList(contacts);
                    break;
                default:
                    StopClient();
                    break;
            }
            return returnjson;
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
