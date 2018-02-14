using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServ.Models
{
    class OneMessage
    {
        public ObjectId _id { get; set; }
        public string Adress { get; set; }
        public string Sender { get; set; }
        public string MessageText { get; set; }
        public bool Readed { get; set; }
        public DateTime DateWrite { get; set; }
    }
}
