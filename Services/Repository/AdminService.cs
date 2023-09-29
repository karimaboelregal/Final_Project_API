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
using E_Commerce.Repository.Unit;

namespace E_Commerce.Repository.Repository
{
    public class AdminService : IAdminService
    {
        private readonly UnitOfWork unitOfWork;
        public AdminService(UnitOfWork _unitOFWork)
        {
            unitOfWork = _unitOFWork;
        }

        public async Task<Admin> AddAdmin(Admin admin)
        {
            unitOfWork.adminRepository.Add(admin);
            unitOfWork.SaveChanges();

            return admin;
        }

        public void DeleteAdmin(Admin admin)
        {
            unitOfWork.adminRepository.Delete(admin);
            unitOfWork.SaveChanges();
        }

        public async Task<Admin> GetAdmin(Guid id)
        {
            Admin ad = await unitOfWork.adminRepository.Get(p => p.Id == id);
            return ad;
        }

        public async Task<List<Admin>> GetAdminList()
        {
            List<Admin> ads = (List<Admin>) await unitOfWork.adminRepository.GetAll();
            return ads;
        }

        public async Task<Admin> UpdateAdmin(Admin admin)
        {
            unitOfWork.adminRepository.Update(admin);
            unitOfWork.SaveChanges();

            return admin;
        }
    }
}
