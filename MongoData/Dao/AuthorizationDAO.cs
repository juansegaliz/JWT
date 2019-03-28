using System;
using System.Collections.Generic;
using System.Text;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoData.Entities;

namespace MongoData.Dao
{
    public class AuthorizationDAO
    {
        private MongoClient _mongoClient;
        private IMongoCollection<MongoData.Entities.Authorization> _authorizationCollection;

        public AuthorizationDAO()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017");
            var database = _mongoClient.GetDatabase("IFKMongoDB");
            _authorizationCollection = database.GetCollection<Authorization>("authorizations"); 
        }

        public List<Authorization> Read()
        {
            var data = _authorizationCollection.AsQueryable<Authorization>().ToList();
            return data;
        }

        public void Create(Authorization authorization)
        {
            Authorization newAuthorization = new Authorization {
                Id_user = authorization.Id_user,
                Username = authorization.Username,
                Role = authorization.Role,
                GUID = authorization.GUID,
                Id_state = authorization.Id_state
            };
            _authorizationCollection.InsertOne(newAuthorization);
        }
    }
}
