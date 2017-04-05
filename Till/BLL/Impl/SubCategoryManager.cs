using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MongoDB.Bson;
using DAL;
using DAL.Impl;

namespace BLL.Impl
{
    public class SubCategoryManager : ISubCategoryManager
    {
        ISubCategoryRepository subCategoryRepository = new SubCategoryRepository();

        SubCategory ISubCategoryManager.Create(SubCategory subCategory)
        {

            if (string.IsNullOrWhiteSpace(subCategory.Name))
            {
                throw new ArgumentException("Please Provide SubCategory Name");
            }

            if (string.IsNullOrWhiteSpace(subCategory.CategoryId))
            {
                throw new ArgumentException("Please Provide Category Id");
            }

            return subCategoryRepository.Create(subCategory);
        }

        void ISubCategoryManager.Delete(ObjectId id)
        {
            subCategoryRepository.Delete(id);
        }

        IEnumerable<SubCategory> ISubCategoryManager.GetSubCategories()
        {
            return subCategoryRepository.GetSubCategories();
        }

        SubCategory ISubCategoryManager.GetSubCategory(ObjectId Id)
        {
            return subCategoryRepository.GetSubCategory(Id);
        }

        void ISubCategoryManager.Update(ObjectId id, SubCategory subCategory)
        {
            if (string.IsNullOrWhiteSpace(subCategory.Name))
            {
                throw new ArgumentException("Please Provide SubCategory Name");
            }
             if (string.IsNullOrEmpty(subCategory.Id.ToString()))
            {
                throw new ArgumentException("Please Provide SubCategory Id");
            }
             if (string.IsNullOrEmpty(subCategory.CategoryId.ToString()))
            {
                throw new ArgumentException("Please Provide Category Id");
            }

            subCategoryRepository.Update(id, subCategory);
        }

        bool ISubCategoryManager.CategoryReferened(string Id)
        {
            return subCategoryRepository.CategoryReferened(Id);
        }
    }
}
