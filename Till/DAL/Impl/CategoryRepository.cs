using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace DAL.Impl
{
    public class CategoryRepository : ICategoryRepository
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public CategoryRepository()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("Sales");
        }

        Category ICategoryRepository.Create(Category category)
        {
            _db.GetCollection<Category>("Category").Save(category);
            return category;
        }

        bool ICategoryRepository.Delete(ObjectId id)
        {
            var res = Query<Category>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Category>("Category").Remove(res);
            return true;
        }

        IEnumerable<Category> ICategoryRepository.GetCategories()
        {
            return _db.GetCollection<Category>("Category").FindAll();
        }

        Category ICategoryRepository.GetCategory(ObjectId Id)
        {
            var res = Query<Category>.EQ(p => p.Id, Id);
            return _db.GetCollection<Category>("Category").FindOne(res);
        }

        void ICategoryRepository.Update(ObjectId id, Category category)
        {
            category.Id = id;
            var res = Query<Category>.EQ(cat => cat.Id, id);
            var operation = Update<Category>.Replace(category);
            _db.GetCollection<Category>("Category").Update(res, operation);
        }
    }
}
