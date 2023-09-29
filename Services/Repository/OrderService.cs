using E_Commerce.Data.Context;
using Models.Models;
using E_Commerce.Repository.Interface;
using Models.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Repository.Unit;

namespace E_Commerce.Repository.Repository
{
    public class OrderService : IOrderService
    {
        private readonly UnitOfWork unitOfWork;
        public OrderService(UnitOfWork _unitOFWork)
        {
            unitOfWork = _unitOFWork;
        }

        public async Task<Order> AddOrder(Order order)
        {
            unitOfWork.orderRepository.Add(order);
            unitOfWork.SaveChanges();

            return order;
        }

        public void DeleteCategory(Order order)
        {
            unitOfWork.orderRepository.Delete(order);
            unitOfWork.SaveChanges();
        }

        public async Task<Order> GetOrder(Guid id)
        {
            Order ad = await unitOfWork.orderRepository.Get(p => p.Id == id);
            return ad;
        }

        public async Task<List<Order>> GetOrdersList()
        {
            List<Order> ads = (List<Order>)await unitOfWork.orderRepository.GetAll();
            return ads;
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            unitOfWork.orderRepository.Update(order);
            unitOfWork.SaveChanges();

            return order;
        }
    }
}
