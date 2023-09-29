using E_Commerce.Data.Context;
using Models.Models;

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Repository;
using E_Commerce.Repository.Unit;
using E_Commerce.Repository.Interface;

namespace E_Commerce.Repository.Repository
{
    public class ProductService : IProductService
    {
        private readonly UnitOfWork unitOfWork;
        public ProductService(UnitOfWork _unitOFWork)
        {
            unitOfWork = _unitOFWork;
        }
        public async Task<List<Product>> GetProductList()
        {
            List<Product> prods = (List<Product>)await unitOfWork.productRepository.GetAll();
            return prods;
        }
        public async Task<List<Product>> GetProductsFromCategory(string id)
        {
            List<Product> prods = (List<Product>)await unitOfWork.productRepository.GetAll(p => p.CategoryId == Guid.Parse(id));
            return prods;
        }
        public async Task<Product> GetProduct(Guid id)
        {
            Product prod = await unitOfWork.productRepository.Get(p => p.Id == id);
            return prod;
        }

        public async Task<Product> UpdateProduct(Product product)
        {

            unitOfWork.productRepository.Update(product);
            unitOfWork.SaveChanges();

            return product;
        }

        public async Task<Product> AddProduct(Product product)
        {
            unitOfWork.productRepository.Add(product);
            unitOfWork.SaveChanges();

            return product;
        }

        public async void DeleteProduct(Product prod)
        {
               unitOfWork.productRepository.Delete(prod);
            unitOfWork.SaveChanges();
        }
    }
}
