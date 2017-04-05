using Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(ObjectId Id);
        Product Create(Product product);
        void Update(ObjectId id, Product product);
        void Delete(ObjectId id);
        bool SubCategoryReferened(string Id);
    }
}
