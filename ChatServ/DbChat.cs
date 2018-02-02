using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatServ.Models;
using System.Configuration;

namespace ChatServ
{
    class DbChat
    {
        private IMongoCollection<Person> collection;
        private IMongoDatabase db;
        public DbChat(string connectionString)
        {
            string con = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
            MongoClient client = new MongoClient(con);
            db = client.GetDatabase("infocenter");
            collection = db.GetCollection<Person>("people");
        }
                
        public List<Person> All()
        {
            List<Person> lst = new List<Person>();
            lst = collection.Find(_ => true).ToList();
            return lst;
        }
    }
}
