using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROR.DataAccess.Mongo
{
    public class User
    {
        public ObjectId _id { get; set; }

        [BsonElement("AJC_PID")]
        public Int64 AJC_PID { get; set; }

        [BsonElement("PERSON_CODE")]
        public Int64 PERSON_CODE { get; set; }

        [BsonElement("PASSWORD")]
        public string PASSWORD { get; set; }
    }
}
