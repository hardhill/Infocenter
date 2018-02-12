﻿using ChatServ.Models;
using Newtonsoft.Json;
using SuperSocket.SocketBase;
using SuperSocket.WebSocket;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        private List<WebSocketSession> Sessions = new List<WebSocketSession>();
        public List<Client> Clients = new List<Client>();

        private WebSocketServer appServer;
        private string _ipadress;
        private int _port;



        public MyServer(string ipadress,int port)
        {
            _ipadress = ipadress;
            _port = port;
            appServer = new WebSocketServer();
                        
            appServer.NewMessageReceived += new SessionHandler<WebSocketSession, string>(AppServer_NewMessageReceived);
            appServer.NewSessionConnected += new SessionHandler<WebSocketSession>(AppServer_NewSessionConnected);
            appServer.NewDataReceived += new SessionHandler<WebSocketSession, byte[]>(AppServer_NewDataReceived);
            appServer.SessionClosed += new SessionHandler<WebSocketSession, CloseReason>(AppServer_SessionClose);
        }

        private void AppServer_SessionClose(WebSocketSession session, CloseReason value)
        {
           Sessions.Remove(session);
           var sessid = session.SessionID;
           CheckOutWorker(sessid);
           OnSessionClose?.Invoke(session, value);
        }

        

        private void AppServer_NewDataReceived(WebSocketSession session, byte[] value)
        {
            OnNewDataRecieved(session, value);
        }

        private void AppServer_NewSessionConnected(WebSocketSession session)
        {
            Sessions.Add(session);
            SendId(session);
            
            OnNewSessionConnected?.Invoke(session);
        }

       

        private void SendId(WebSocketSession session)
        {
            Client cl = new Client();
            Comm comm = new Comm();
            string value = "";
            cl.IdSession = session.SessionID;
            cl.TimeIn = DateTime.Now;
            comm.CommName = "SENDID";
            comm.Body = cl;
            value = JsonConvert.SerializeObject(comm, Formatting.None);
            session.Send(value);
        }

        private void AppServer_NewMessageReceived(WebSocketSession session, string value)
        {
            ControllerCommandIn(session,value);
            OnNewMessageRecieved?.Invoke(session, value);
        }

        private string ControllerCommandIn(WebSocketSession session,string commandvalue)
        {
            string returnjson = "";
            Comm comm = JsonConvert.DeserializeObject<Comm>(commandvalue);
            string commandName = comm.CommName;
            

            switch (commandName)
            {
                case "NEWUSER":
                    Client cli = new Client();
                    //разбираем тело команды
                    cli = JsonConvert.DeserializeObject<Client>(comm.Body.ToString());
                    //проверка на пользователя в БД (есть ли такой пользователь)
                    if (CheckUserName(cli.UserName))
                    {
                        List<ContactUser> contacts = new List<ContactUser>();
                        Clients.Add(new Client() { IdSession = cli.IdSession, UserName = cli.UserName });
                        //зачекинить пользователя в БД
                        CheckInWorker(cli);
                        //заполнить список всех контактов
                        FillContacts(contacts);
                        //отправить инфу для клиента (всех активных и неактивных пользователей сети)
                        Comm comm_res = new Comm() { CommName = "NEWUSER", Body = contacts };
                        returnjson = JsonConvert.SerializeObject(comm_res);
                        appServer.Broadcast(Sessions, returnjson, null);
                    }
                    break;
                case "WORKERS":
                    Client cli_connected = new Client();
                    cli_connected = JsonConvert.DeserializeObject<Client>(comm.Body.ToString());
                    if(Clients != null)
                    {
                        List<WorkersTime> wrks = new List<WorkersTime>();
                        wrks = ActiveWorkers(Clients);
                        //отправить инфу для клиента (всех активных и неактивных пользователей сети)
                        Comm comm_res = new Comm() { CommName = "WORKERS", Body = wrks };
                        returnjson = JsonConvert.SerializeObject(comm_res);
                        session.Send(returnjson);
                    }
                    break;
                case "MSG":
                    MessageSend msg = new MessageSend();
                    msg = JsonConvert.DeserializeObject<MessageSend>(comm.Body.ToString());
                    if (msg != null)
                    {
                        AddToHistoryMessages(msg);
                        //отправка оссобщения адресату
                        returnjson = SendMessageToUser(msg);
                        
                    }
                    break;
                default:
                    
                    break;
            }
            return returnjson;
        }

        private string SendMessageToUser(MessageSend msg)
        {
            string usr = msg.Adress;
            Client client = Clients.FindLast(x => x.UserName.ToLower() == usr.ToLower());
            Comm com_resp = new Comm();
            com_resp.CommName = "MSG";
            com_resp.Body = new MessageSend() { Adress = msg.Adress, Sender = msg.Sender, Message = msg.Message };
            string json = JsonConvert.SerializeObject(com_resp);
            appServer.GetSessionByID(client.IdSession).Send(json);
            return json;
        }



        //---------------------------------------- With DB Mongo -------------------------------------------

        private void AddToHistoryMessages(MessageSend msg)
        {
            //добавить в историю сообщений
            DbChat db = new DbChat("MongoDb");
            
        }

        private void CheckInWorker(Client cli)
        {
            DbChat db = new DbChat("MongoDb");
            db.CheckInWorker(cli).GetAwaiter().GetResult();
        }

        private void CheckOutWorker(string sessid)
        {
            DbChat db = new DbChat("MongoDb");
            Client cli = Clients.Find(x => x.IdSession == sessid);
            if (cli != null)
            {
                db.CheckOutWorker(cli).GetAwaiter().GetResult();
            }

        }
        private List<WorkersTime> ActiveWorkers(List<Client> clients)
        {
            DbChat db = new DbChat("MongoDb");
            return db.ActiveWorkers(clients);
        }

        private bool CheckUserName(string userName)
        {
            bool ch;
            DbChat dbChat = new DbChat("MongoDb");
            ch = dbChat.ContainUser(userName);
            return ch;
        }

        //заполнить список контактов присоединенных и из БД
        private void FillContacts(List<ContactUser> contacts)
        {
            contacts.Clear();
            DbChat dbChat = new DbChat("MongoDb");
            List<Person> allPerson = new List<Person>();
            allPerson.AddRange(dbChat.All());
            foreach(var cli in Clients)
            {
                string winlogin = cli.UserName;
                string id = cli.IdSession;
                string fa = allPerson.Find(x => x.Winlogin.ToLower() == winlogin.ToLower()).Fa;
                string im = allPerson.Find(x => x.Winlogin.ToLower() == winlogin.ToLower()).Im;
                string ot = allPerson.Find(x => x.Winlogin.ToLower() == winlogin.ToLower()).Ot;
                long dt = allPerson.Find(x => x.Winlogin.ToLower() == winlogin.ToLower()).Bday;
                contacts.Add(new ContactUser() { SessionId = id, Winlogin = winlogin, Fa = fa, Im = im, Ot = ot, Bday = new DateTime(dt) });
            }
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

        private class Comm
        {
            public string CommName { get; set; }
            public Object Body { get; set; }
        }

        private class MessageSend
        {
            public string Adress { get; set; }
            public string Sender { get; set; }
            public string Message { get; set; }
        }
    }
}
