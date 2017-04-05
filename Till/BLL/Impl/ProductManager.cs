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
    public class ProductManager : IProductManager
    {
        IProductRepository productRepository = new ProductRepository();

        Product IProductManager.Create(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new ArgumentException("Please Provide Product Name");
            }

            if (string.IsNullOrWhiteSpace(product.SubCategoryId))
            {
                throw new ArgumentException("Please Provide SubCategory Id");
            }

            return productRepository.Create(product);
        }

        void IProductManager.Delete(ObjectId id)
        {
            productRepository.Delete(id);
        }

        IEnumerable<Product> IProductManager.GetProducts()
        {
            return productRepository.GetProducts();
        }

        Product IProductManager.GetProduct(ObjectId Id)
        {
            return productRepository.GetProduct(Id);
        }

        void IProductManager.Update(ObjectId id, Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new ArgumentException("Please Provide Product Name");
            }
            if (string.IsNullOrEmpty(product.Id.ToString()))
            {
                throw new ArgumentException("Please Provide Product Id");
            }
            if (string.IsNullOrEmpty(product.SubCategoryId.ToString()))
            {
                throw new ArgumentException("Please Provide SubCategory Id");
            }

            productRepository.Update(id, product);
        }

        bool IProductManager.SubCategoryReferened(string Id)
        {
            return productRepository.SubCategoryReferened(Id);
        }
    }
}
