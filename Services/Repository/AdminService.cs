using E_Commerce.Data.Context;
using Models.Models;
using E_Commerce.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Models.Models;

namespace E_Commerce.Repository.Repository
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork unitOfWork;
        public AdminService(IUnitOfWork _unitOFWork)
        {
            unitOfWork = _unitOFWork;
        }
    }
}
