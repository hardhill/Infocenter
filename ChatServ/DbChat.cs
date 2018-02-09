using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatServ.Models;
using System.Configuration;
using MongoDB.Bson;

namespace ChatServ
{
    class DbChat
    {
        private IMongoCollection<Person> coll_people;
        private IMongoCollection<Tracking> coll_tracking;
        private IMongoDatabase db;
        public DbChat(string connectionString)
        {
            string con = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
            MongoClient client = new MongoClient(con);
            db = client.GetDatabase("infocenter");
            coll_people = db.GetCollection<Person>("people");
            coll_tracking = db.GetCollection<Tracking>("tracking");
        }
                
        public List<Person> All()
        {
            List<Person> lst = new List<Person>();
            lst = coll_people.Find(_ => true).ToList();
            return lst;
        }

        internal bool ContainUser(string userName)
        {
            long n = coll_people.Count(x => x.Winlogin.ToLower() == userName.ToLower());
            return n > 0;
        }

        internal async Task CheckOutWorker(Client cli)
        {
            var builder = Builders<Tracking>.Filter;
            var filter = builder.Eq("Winlogin", cli.UserName)&builder.Eq("DateOut",DateTime.MinValue)&builder.Eq("SessionId",cli.IdSession);
            var update = Builders<Tracking>.Update.Set("DateOut", DateTime.Now);
            var result = await coll_tracking.UpdateOneAsync(filter, update);
        }

        internal async Task CheckInWorker(Client cli)
        {
            Tracking tracking = new Tracking() { SessionId = cli.IdSession,  Winlogin = cli.UserName ,DateIn = DateTime.Now, DateOut=DateTime.MinValue };
            await coll_tracking.InsertOneAsync(tracking);
        }

        internal List<WorkersTime> ActiveWorkers(List<Client> clients)
        {
            List<WorkersTime> lstWorks = new List<WorkersTime>();
            foreach(var cli in clients)
            {
                WorkersTime wrkt = new WorkersTime();
                wrkt.Winlogin = cli.UserName;
                wrkt.Fa = GetFabyLogin(cli.UserName);
                wrkt.Im = GetImbyLogin(cli.UserName);
                wrkt.Ot = GetOtbyLogin(cli.UserName);
                wrkt.WorkBegin = GetWorkBeginbySession(cli.IdSession);
                var verify = GetWorkEndbySession(cli.IdSession);
                if (verify > DateTime.MinValue) wrkt.WorkEnd = verify;
                lstWorks.Add(wrkt);
            }
            return lstWorks;
        }

        private DateTime GetWorkEndbySession(string idSession)
        {
            var result = coll_tracking.Find(x => x.SessionId == idSession).ToList();
            if (result != null & result.Count > 0)
            {
                return (result[0].DateOut);
            }
            return DateTime.MinValue;
        }

        private DateTime GetWorkBeginbySession(string idSession)
        {
            var result = coll_tracking.Find(x => x.SessionId == idSession).ToList();
            if (result != null & result.Count > 0)
            {
                return result[0].DateIn;
            }
            return DateTime.MinValue;
        }

        private string GetOtbyLogin(string userName)
        {
            var result = coll_people.Find(x => x.Winlogin.ToLower() == userName.ToLower()).ToList();
            if (result != null)
            {
                if (result.Count > 0)
                {
                    return result[0].Ot;
                }
            }
            return "";
        }

        private string GetImbyLogin(string userName)
        {
            var result = coll_people.Find(x => x.Winlogin.ToLower() == userName.ToLower()).ToList();
            if (result != null)
            {
                if (result.Count > 0)
                {
                    return result[0].Im;
                }
            }
            return "";
        }

        private string GetFabyLogin(string userName)
        {
          var result = coll_people.Find(x => x.Winlogin.ToLower() == userName.ToLower()).ToList();
            if (result != null)
            {
                if (result.Count > 0)
                {
                    return result[0].Fa;
                }
            }
            return "";   
        }
    }
}
