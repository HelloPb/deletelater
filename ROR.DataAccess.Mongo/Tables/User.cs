using ROR.Auth.Interfaces;
using System;
using System.Collections.Generic;
using ROR.DataAccess.Mongo.Models;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace ROR.DataAccess.Mongo
{
    public class TUser : IDataAccess<User>
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public TUser()
        {
            _client = new MongoClient("");
            _server = _client.GetServer();
            _db = _server.GetDatabase("");
        }

        public void delete(string Id)
        {
            ObjectId id = new ObjectId();
            var res = Query<User>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<User>("Users").Remove(res);
        }

        public User get(string Id)
        {
            ObjectId id = new ObjectId();
            var res = Query<User>.EQ(p => p.Id, id);
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

            user.Id = id;
            var res = Query<User>.EQ(pd => pd.Id, id);
            var operation = Update<User>.Replace(user);
            _db.GetCollection<User>("Users").Update(res, operation);
        }

        public IEnumerable<User> search()
        {
            return _db.GetCollection<User>("Users").FindAll();
        }
    }
}
