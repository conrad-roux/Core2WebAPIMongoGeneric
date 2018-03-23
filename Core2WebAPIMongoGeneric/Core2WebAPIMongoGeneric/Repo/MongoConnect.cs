using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core2WebAPIMongoGeneric.Repo
{
    public class MongoConnect
    {
        public const string DATABASE_NAME = "UserTest";
        private static readonly IMongoClient _client;
        private static readonly IMongoDatabase _database;

        static MongoConnect()
        {
            var connectionString = "mongodb://localhost:27017";
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(DATABASE_NAME);
        }

        public IMongoClient Client
        {
            get { return _client; }
        }

        public IMongoDatabase Database
        {
            get { return _database; }
        }
    }
}
