using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROR.DataAccess.Mongo
{
    public class UserDto
    {
        public Int64 ajc_pid { get; set; }
        public Int64 person_code { get; set; }
        public string password { get; set; }
    }
}
