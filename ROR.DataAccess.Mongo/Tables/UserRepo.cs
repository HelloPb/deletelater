using ROR.Auth.Interfaces;
using System;
using System.Collections.Generic;
using ROR.DataAccess.Mongo;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;
using System.Security.Authentication;
using Microsoft.Extensions.Configuration;

namespace ROR.DataAccess.Mongo
{
    public class UserRepo : IDataAccess<User>
    {
        private MongoClient _client;
        private MongoServer _server;
        private MongoDatabase _db;
        private IConfiguration _config;

        public UserRepo(IConfiguration config)
        {
            _config = config;

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(_config["connectionString:mongodb"]));

            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            _client = new MongoClient(settings);

            _server = _client.GetServer();

            _db = _server.GetDatabase("rorusers");
        }
        
        public void delete(string Id)
        {
            ObjectId id = new ObjectId();
            var res = Query<User>.EQ(e => e.AJC_PID, long.Parse(Id));
            var operation = _db.GetCollection<User>("Users").Remove(res);
        }

        public User get(long Id)
        {
            var res = Query<User>.EQ(e => e.AJC_PID, Id);
            return _db.GetCollection<User>("Users").FindOne(res);
        }

        public User post(User user)
        {
            _db.GetCollection<User>("Users").Save(user);
            return user;
        }

        public void put(string Id, User user)
        {
            ObjectId id = new ObjectId();

            user._id = id;
            var res = Query<User>.EQ(pd => pd._id, id);
            var operation = Update<User>.Replace(user);
            _db.GetCollection<User>("Users").Update(res, operation);
        }

        public IEnumerable<User> search()
        {
            return _db.GetCollection<User>("Users").FindAll();
        }
    }
}
