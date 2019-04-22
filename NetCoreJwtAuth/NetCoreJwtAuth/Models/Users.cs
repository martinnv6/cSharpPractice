using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreJwtAuth.Models
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Key")]
        public string Key { get; set; }
        [BsonElement("Token")]
        public string Token { get; set; }

        [BsonElement("NameAdmin")]
        public string NameAdmin { get; set; }

        [BsonElement("System")]
        public string System { get; set; }

        [BsonElement("Controller")]
        public string Controller { get; set; }
    }
}
