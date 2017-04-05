using Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class DataAccess
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("Sales");
        }

        public IEnumerable<Category> GetCategories()
        {
            return _db.GetCollection<Category>("Category").FindAll();
        }

        //NarendraKlb@gmail.com 

        public Category GetCategory(ObjectId Id)
        {
            var res = Query<Category>.EQ(p => p.Id, Id);
            return _db.GetCollection<Category>("Category").FindOne(res);
        }

        public Category Create(Category category)
        {
            _db.GetCollection<Category>("Category").Save(category);
            return category;
        }

        public void Update(ObjectId id, Category category)
        {
            category.Id = id;
            var res = Query<Category>.EQ(cat => cat.Id, id);
            var operation = Update<Category>.Replace(category);
            _db.GetCollection<Category>("Category").Update(res, operation);
        }

        public void Delete(ObjectId id)
        {
            var res = Query<Category>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Category>("Category").Remove(res); 
        }
    }
}
