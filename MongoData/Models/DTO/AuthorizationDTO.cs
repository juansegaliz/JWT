using System;
using System.Collections.Generic;
using System.Text;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace MongoData.Models.DTO
{
    public class AuthorizationDTO
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("id_user")]
        public int Id_user { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }

        [BsonElement("guid")]
        public string GUID { get; set; }

        [BsonElement("role")]
        public string Role { get; set; }

        [BsonElement("id_state")]
        public int Id_state { get; set; }
    }
}
