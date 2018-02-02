using ic2.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ic2
{
    public class dbContext
    {
        private IMongoCollection<Person> collection;
        public dbContext(IMongoCollection<Person> collect)
        {
            collection = collect;
        }
        public List<Person> All()
        {
            List<Person> lst = new List<Person>();
            lst = collection.Find(_=>true).ToList();
            return lst;
        }

        public void Update(Person person)
        {
            collection.ReplaceOne(x=>(x._id==person._id), person);
        }

        internal void Insert(Person person)
        {
            collection.InsertOne(person);
        }

        internal void Delete(Person person)
        {
            collection.DeleteOne(x => (x._id == person._id));
        }
    }
}
