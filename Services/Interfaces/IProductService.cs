using Models.Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetProductList();
        Task<List<Product>> GetProductsFromCategory(string id);
        Task<Product> GetProduct(Guid id);

        Task<Product> UpdateProduct(Product product);

        Task<Product> AddProduct(Product product);

        void DeleteProduct(Product prod);
    }
}
