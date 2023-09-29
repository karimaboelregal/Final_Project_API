using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E_Commerce.Data.Context;
using Models.Models;
using E_Commerce.Repository.Interface;
using E_Commerce.Repository.Repository;
using Web_API.Model;
using Microsoft.AspNetCore.Authorization;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminsController : ControllerBase
    {
       
        private readonly IAdminService _adminservice;
        public AdminsController( IAdminService adminService)
        {
        
            _adminservice = adminService;   

        }

        // GET: api/Admins
        [HttpGet]
        public async Task<ActionResult<List<Admin>>> GetAdmins()
        {
            var pro = await _adminservice.GetAdminList();
            return Ok(pro);
        }

        // GET: api/Admins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin(Guid id)
        {
            var admin = await _adminservice.GetAdmin(id);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        // PUT: api/Admins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(AdminAPIModel adminapimodel)
        {
            var c = await _adminservice.GetAdmin(adminapimodel.Id);

            c.FullName = adminapimodel.FullName;
            c.JobTitle = adminapimodel.JobTitle;

            _adminservice.UpdateAdmin(c);

            return Ok();
        }

        // POST: api/Admins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin(AdminAPIModel admin)
        {
            Admin p = new() {FullName=admin.FullName,JobTitle=admin.JobTitle};
            _adminservice.AddAdmin(p);  


            return Ok();
        }

        // DELETE: api/Admins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(Guid id)
        {
            var prod = await _adminservice.GetAdmin(id);
            _adminservice.DeleteAdmin(prod);
            return Ok();
        }

 
    }
}
