using Models.Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Interface
{
    public interface IAdminService
    {
        Task<List<Admin>> GetAdminList();

        Task<Admin> GetAdmin(Guid id);

        Task<Admin> UpdateAdmin(Admin admin);

        Task<Admin> AddAdmin(Admin admin);

        void DeleteAdmin(Admin admin);
    }
}
