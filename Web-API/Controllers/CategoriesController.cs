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
    public class CategoriesController : ControllerBase
    {
      
        private readonly ICategoryService _categoryservice;

        public CategoriesController(ICategoryService categoryService)
        {
   
            _categoryservice = categoryService;

        }

        // GET: api/Categories
        [HttpGet]
        [Route("getcategories")]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            var pro = await _categoryservice.GetCategoryList();
            return Ok(pro);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(Guid id)
        {
            var category = await _categoryservice.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(CategoryAPIModel categoryAPIModel)
        {
            var c = await _categoryservice.GetCategory(categoryAPIModel.id);

                c.Name = categoryAPIModel.Name;
            _categoryservice.UpdateCategory(c);

            return Ok();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(CategoryAPIModel categoryAPIModel)
        {
            Category p = new() {Name= categoryAPIModel.Name, CreatedOn = DateTime.Now };
            _categoryservice.AddCategory(p);


            return Ok();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var prod = await _categoryservice.GetCategory(id);
                _categoryservice.DeleteCategory(prod);  
            return Ok();
        }

 
    }
}
