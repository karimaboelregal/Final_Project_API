using E_Commerce.Data.Context;
using Models.Models;
using E_Commerce.Repository.Interface;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Repository
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly IUnitOfWork unitOfWork;
        public OrderDetailsService(IUnitOfWork _unitOFWork)
        {
            unitOfWork = _unitOFWork;
        }

    }
}
