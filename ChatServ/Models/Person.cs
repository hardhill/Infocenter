using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServ.Models
{
    public class Person
    {
        public ObjectId _id { get; set; }
        public string Winlogin {get; set;}
        public string Fa { get; set; }
        public string Im { get; set; }
        public string Ot { get; set; }
        [BsonIgnoreIfDefault]
        public long Bday { get; set; }        //дата рождения
    }
}
