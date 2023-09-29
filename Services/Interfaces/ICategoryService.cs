using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Interface
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoryList();
      
        Task<Category> GetCategory(Guid id);

        Task<Category> UpdateCategory(Category category);

        Task<Category> AddCategory(Category category);

        void DeleteCategory(Category category);
    }
}
