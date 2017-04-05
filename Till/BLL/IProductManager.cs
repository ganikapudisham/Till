using Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IProductManager
    {
        Product Create(Product product);
        Product GetProduct(ObjectId Id);
        void Update(ObjectId id, Product product);
        void Delete(ObjectId id);
        IEnumerable<Product> GetProducts();
        bool SubCategoryReferened(string Id);
    }
}
