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
    public class SubCategoryRepository : ISubCategoryRepository
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public SubCategoryRepository()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("Sales");
        }

        SubCategory ISubCategoryRepository.Create(SubCategory subCategory)
        {
            _db.GetCollection<SubCategory>("SubCategory").Save(subCategory);
            return subCategory;
        }

        bool ISubCategoryRepository.Delete(ObjectId id)
        {
            var res = Query<SubCategory>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<SubCategory>("SubCategory").Remove(res);
            return true;
        }

        IEnumerable<SubCategory> ISubCategoryRepository.GetSubCategories()
        {
            return _db.GetCollection<SubCategory>("SubCategory").FindAll();
        }

        SubCategory ISubCategoryRepository.GetSubCategory(ObjectId Id)
        {
            var res = Query<SubCategory>.EQ(p => p.Id, Id);
            return _db.GetCollection<SubCategory>("SubCategory").FindOne(res);
        }

        void ISubCategoryRepository.Update(ObjectId id, SubCategory subCategory)
        {
            subCategory.Id = id;
            var res = Query<Category>.EQ(cat => cat.Id, id);
            var operation = Update<SubCategory>.Replace(subCategory);
            _db.GetCollection<SubCategory>("SubCategory").Update(res, operation);
        }

        bool ISubCategoryRepository.CategoryReferened(string Id)
        {
            var collection = _db.GetCollection<SubCategory>("SubCategory");
            var query = Query<SubCategory>.EQ(p => p.CategoryId, Id);
            MongoCursor<SubCategory> cursor = collection.Find(query);
            if (cursor.Count() >= 1) { return true; }
            else
            {
                return false;
            }
        }
    }
}
