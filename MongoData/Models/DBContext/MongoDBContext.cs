using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;


namespace MongoData.Models.DBContext
{
    public class MongoDBContext
    {
        public string connectionString = "mongodb://localhost:27017";

        protected MongoClient _mongoClient;
        public IMongoDatabase Database;

        public MongoDBContext()
        {
            _mongoClient = new MongoClient(connectionString);
            Database = _mongoClient.GetDatabase("IFKMongoDB");
        }
    }
}
