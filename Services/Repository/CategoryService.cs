using E_Commerce.Data.Context;
using Models.Models;
using E_Commerce.Repository.Interface;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Repository.Unit;

namespace E_Commerce.Repository.Repository
{
    public class CategoryService : ICategoryService
    {
        private readonly UnitOfWork unitOfWork;
        public CategoryService(UnitOfWork _unitOFWork)
        {
            unitOfWork = _unitOFWork;
        }

        public async Task<Category> AddCategory(Category category)
        {
            unitOfWork.categoryRepository.Add(category);
            unitOfWork.SaveChanges();

            return category;
        }

        public void DeleteCategory(Category category)
        {
            unitOfWork.categoryRepository.Delete(category);
            unitOfWork.SaveChanges();
        }

        public async Task<Category> GetCategory(Guid id)
        {
            Category cat = await unitOfWork.categoryRepository.Get(p => p.Id == id);
            return  cat;
        }

        public async Task<List<Category>> GetCategoryList()
        {
            List<Category> cats = (List<Category>)await unitOfWork.categoryRepository.GetAll();
            return cats;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            unitOfWork.categoryRepository.Update(category);
            unitOfWork.SaveChanges();

            return category;
        }
    }
}
