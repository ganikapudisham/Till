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
    public class ProductRepository : IProductRepository
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;

        public ProductRepository()
        {
            _client = new MongoClient("mongodb://tillstore:d5r4GpgWKDeJgWWhKFd9rN6V8zBRYVWmGQLB4GZMzpzfOp4zk2sK0p0YC5QZJ2yiYpSQrq0Uffxf6vMXR2ElMw==@tillstore.documents.azure.com:10250/?ssl=true");
            _server = _client.GetServer();
            _db = _server.GetDatabase("Sales");
        }

        Product IProductRepository.Create(Product product)
        {
            _db.GetCollection<Product>("Product").Save(product);
            return product;
        }

        void IProductRepository.Delete(ObjectId id)
        {
            var res = Query<Product>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<Product>("Product").Remove(res);
        }

        IEnumerable<Product> IProductRepository.GetProducts()
        {
            return _db.GetCollection<Product>("Product").FindAll();
        }

        Product IProductRepository.GetProduct(ObjectId Id)
        {
            var res = Query<Product>.EQ(p => p.Id, Id);
            return _db.GetCollection<Product>("Product").FindOne(res);
        }

        void IProductRepository.Update(ObjectId id, Product product)
        {
            product.Id = id;
            var res = Query<Product>.EQ(cat => cat.Id, id);
            var operation = Update<Product>.Replace(product);
            _db.GetCollection<Product>("Product").Update(res, operation);
        }

        bool IProductRepository.SubCategoryReferened(string Id)
        {
            var collection = _db.GetCollection<Product>("Product");
            var query = Query<Product>.EQ(p => p.SubCategoryId, Id);
            MongoCursor<Product> cursor = collection.Find(query);
            if (cursor.Count() >= 1) { return true; }
            else
            {
                return false;
            }
        }
    }
}
