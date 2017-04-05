using Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ICategoryManager
    {
        Category Create(Category category);
        Category GetCategory(ObjectId Id);
        void Update(ObjectId id, Category category);
        bool Delete(ObjectId id);
        IEnumerable<Category> GetCategories();
    }
}
