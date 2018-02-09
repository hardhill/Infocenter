using MongoDB.Bson;

namespace ChatServ.Models
{
    public class Tracking
    {
        public ObjectId _id { get; set; }
        public string SessionId { get; set; }
        public string Winlogin { get; set; }
        public long DateIn { get; set; }
        public long DateOut { get; set; }
    }
}