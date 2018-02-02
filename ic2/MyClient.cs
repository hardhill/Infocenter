using System;
using System.Collections.Generic;
using System.Linq;
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

        private WebSocket webSocket;
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
    }
}
