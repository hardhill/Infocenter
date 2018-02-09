using MongoDB.Bson;
using System;

namespace ChatServ.Models
{
    public class Tracking
    {
        public ObjectId _id { get; set; }
        public string SessionId { get; set; }
        public string Winlogin { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
    }
}