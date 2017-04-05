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
    public class CategoryManager : ICategoryManager
    {
        ICategoryRepository categoryRepository = new CategoryRepository();
        ISubCategoryManager subCategoryManager = new SubCategoryManager();

        Category ICategoryManager.Create(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                throw new ArgumentException("Please Provide Category Name");
            }

            return categoryRepository.Create(category);
        }

        bool ICategoryManager.Delete(ObjectId id)
        {
            
            return categoryRepository.Delete(id);
             
        }

        IEnumerable<Category> ICategoryManager.GetCategories()
        {
            return categoryRepository.GetCategories();
        }

        Category ICategoryManager.GetCategory(ObjectId Id)
        {
            return categoryRepository.GetCategory(Id);
        }

        void ICategoryManager.Update(ObjectId id, Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                throw new ArgumentException("Please Provide Category Name");
            }
            if (string.IsNullOrEmpty(category.Id.ToString()))
            {
                throw new ArgumentException("Please Provide Category Id");
            }


            categoryRepository.Update(id, category);
        }
    }
}
