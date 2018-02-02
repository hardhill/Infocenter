using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.WebSocket;
using Newtonsoft.Json;

namespace ChatServ.Commands
{
    public class Commander
    {
        public string USERS()
        {
            string json_str = "";
            return json_str;
        }

        internal string NewServerUser(List<Client> lstClient, WebSocketSession session)
        {
            Client cl = new Client();
            Comm comm = new Comm();
            string value = "";
            cl.IdSession = session.SessionID;
            cl.TimeIn = DateTime.Now;
            comm.CommName = "NEWUSER";
            comm.obj = cl;
            lstClient.Add(cl);
            value = JsonConvert.SerializeObject(comm);
            return value;
        }

        private class Comm
        {
            public string CommName { get; set; }
            public Object obj { get; set; }
        }
    }

}
