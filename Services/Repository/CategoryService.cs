using E_Commerce.Data.Context;
using Models.Models;
using E_Commerce.Repository.Interface;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Repository
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        public CategoryService(IUnitOfWork _unitOFWork)
        {
            unitOfWork = _unitOFWork;
        }
    }
}
