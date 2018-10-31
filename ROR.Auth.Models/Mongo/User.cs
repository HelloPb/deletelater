using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROR.DataAccess.Mongo.Models
{
    public class User
    {
        public ObjectId Id { get; set; }
        [BsonElement("AJCP_ID")]
        public string AJCP_ID { get; set; }
        [BsonElement("PID")]
        public string PID { get; set; }
        [BsonElement("Password")]
        public string Password { get; set; }
    }
}
