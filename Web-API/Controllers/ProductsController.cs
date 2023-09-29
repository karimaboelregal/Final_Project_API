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
using Web_API.Model;
using Microsoft.AspNetCore.Authorization;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
   
        private readonly IProductService _productservice;

        public ProductsController(IProductService productService)
        {
       
            _productservice = productService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {

            var pro = await _productservice.GetProductList();
            return  Ok(pro);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
        
            var product = await _productservice.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(ProductAPIModel product)
        {

            var p = await _productservice.GetProduct(product.Id);

            p.CategoryId = product.CategoryId;
            p.NameEn = product.NameEn;
            p.NameAr = product.NameAr;
            p.UnitPrice = product.UnitPrice;
            p.StockQuantity = product.StockQuantity;
            _productservice.UpdateProduct(p);

           return Ok();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductAPIModel product)
        {
            Product p = new() {NameAr = product.NameAr,NameEn= product.NameEn, CategoryId=product.CategoryId,UnitPrice=product.UnitPrice ,StockQuantity = product.StockQuantity,CreatedOn=DateTime.Now};    
           _productservice.AddProduct(p);   
         

            return Ok();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
           var prod = await _productservice.GetProduct(id);
            _productservice.DeleteProduct(prod);
            return Ok();    
        }

     
    }
}
