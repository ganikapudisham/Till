using Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ISubCategoryManager
    {
        SubCategory Create(SubCategory subCategory);
        SubCategory GetSubCategory(ObjectId Id);
        void Update(ObjectId id, SubCategory subCategory);
        void Delete(ObjectId id);
        IEnumerable<SubCategory> GetSubCategories();
        bool CategoryReferened(string Id);
    }
}
