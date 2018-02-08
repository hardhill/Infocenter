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
            long n = coll_people.Count(x => x.Winlogin == userName);
            return n > 0;
        }

        internal async Task CheckOutWorker(string winlogin)
        {
            var builder = Builders<Tracking>.Filter;
            var filter = builder.Eq("Winlogin", winlogin)&builder.Eq("DateOut",0)&builder.Lt("DateIn",DateTime.Now.Ticks);
            var update = Builders<Tracking>.Update.Set("DateOut", DateTime.Now.Ticks);
            var result = await coll_tracking.UpdateOneAsync(filter, update);
        }

        internal async Task CheckInWorker(string userName)
        {
            Tracking tracking = new Tracking() { Winlogin = userName,DateIn = DateTime.Now.Ticks, DateOut=0 };
            await coll_tracking.InsertOneAsync(tracking);
        }
    }
}
