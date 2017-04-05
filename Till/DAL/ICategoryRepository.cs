using Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        Category GetCategory(ObjectId Id);
        Category Create(Category category);
        void Update(ObjectId id, Category category);
        bool Delete(ObjectId id);
    }
}
