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
    public class OrdersController : ControllerBase
    {
    
        private readonly IOrderService _orderService;   

        public OrdersController(IOrderService orderService)
        {
          
            _orderService = orderService;   
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var pro = await _orderService.GetOrdersList();
            return Ok(pro);
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(Guid id)
        {
            var order = await _orderService.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(OrderAPIModel order)
        {
            var c = await _orderService.GetOrder(order.Id);

                c.Status = order.Status;    

            _orderService.UpdateOrder(c);

            return Ok();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       
    }
}
