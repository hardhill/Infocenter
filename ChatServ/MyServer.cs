using ChatServ.Commands;
using SuperSocket.SocketBase;
using SuperSocket.WebSocket;
using System;
using System.Collections.Generic;

namespace ChatServ
{
    class MyServer
    {
        public delegate void ErrorSetupInit(string error);
        public delegate void ErrorStartServer(string error);
        public delegate void StartServer(DateTime dt);
        public delegate void StopServer(DateTime dt);
        public delegate void SessionClose(WebSocketSession session, CloseReason value);
        public delegate void NewDataRecieved(WebSocketSession session, byte[] value);
        public delegate void NewSessionConnected(WebSocketSession session);
        public delegate void NewMessageRecieved(WebSocketSession session, string value);
        public event ErrorSetupInit OnErrorSetupInit;
        public event ErrorStartServer OnErrorStartServer;
        public event StartServer OnStartServer;
        public event StopServer OnStopServer;
        public event SessionClose OnSessionClose;
        public event NewDataRecieved OnNewDataRecieved;
        public event NewSessionConnected OnNewSessionConnected;
        public event NewMessageRecieved OnNewMessageRecieved;

        public Commander Command;
        public List<Client> Clients { get; set; }

        private WebSocketServer appServer;
        private string _ipadress;
        private int _port;



        public MyServer(string ipadress,int port)
        {
            _ipadress = ipadress;
            _port = port;
            appServer = new WebSocketServer();
            Command = new Commander();
            
            appServer.NewMessageReceived += new SessionHandler<WebSocketSession, string>(AppServer_NewMessageReceived);
            appServer.NewSessionConnected += new SessionHandler<WebSocketSession>(AppServer_NewSessionConnected);
            appServer.NewDataReceived += new SessionHandler<WebSocketSession, byte[]>(AppServer_NewDataReceived);
            appServer.SessionClosed += new SessionHandler<WebSocketSession, CloseReason>(AppServer_SessionClose);
        }

        private void AppServer_SessionClose(WebSocketSession session, CloseReason value)
        {
            OnSessionClose?.Invoke(session, value);
        }

        private void AppServer_NewDataReceived(WebSocketSession session, byte[] value)
        {
            OnNewDataRecieved(session, value);
        }

        private void AppServer_NewSessionConnected(WebSocketSession session)
        {
            OnNewSessionConnected(session);
        }

        private void AppServer_NewMessageReceived(WebSocketSession session, string value)
        {
            OnNewMessageRecieved(session, value);
        }

        public void Setup()
        {
            if (!appServer.Setup(_ipadress,_port))
            {
                OnErrorSetupInit("Error init server");
            }
            else
            {
                //создать список клиентов
                Clients = new List<Client>();
            }
        }

        public void Start()
        {
            string err = "";
            try
            {
                if (!appServer.Start())
                {
                    err = "Error on start server!";
                    if (appServer.State == SuperSocket.SocketBase.ServerState.Running)
                    {
                        err = "Server already running";
                    }
                    OnErrorStartServer(err);
                }
                else
                {
                    OnStartServer(appServer.StartedTime);
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Stop()
        {
            if (appServer.State != SuperSocket.SocketBase.ServerState.NotStarted)
            {
                appServer.Stop();
                OnStopServer(DateTime.Now);
            }
        }

        public void Broadcast(IEnumerable<WebSocketSession> sessions, string message, Action<WebSocketSession,bool>feedBack)
        {
            appServer.Broadcast(sessions, message, sendFeedback: feedBack);
        }

        public string GetAllUsers()
        {
            string value = "";

            return value;
        }
    }
}
