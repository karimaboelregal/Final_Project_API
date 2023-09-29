using Models.Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Interface
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersList();

        Task<Order> GetOrder(Guid id);

        Task<Order> UpdateOrder(Order order);

        Task<Order> AddOrder(Order order);

        void DeleteCategory(Order order);
    }
}
