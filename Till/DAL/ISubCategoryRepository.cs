using Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ISubCategoryRepository
    {
        IEnumerable<SubCategory> GetSubCategories();
        SubCategory GetSubCategory(ObjectId Id);
        SubCategory Create(SubCategory subCategory);
        void Update(ObjectId id, SubCategory subCategory);
        bool Delete(ObjectId id);
        bool CategoryReferened(string Id);
    }
}
