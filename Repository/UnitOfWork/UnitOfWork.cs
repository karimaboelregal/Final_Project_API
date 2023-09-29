using E_Commerce.Data.Context;
using E_Commerce.Repository.Interface;
using E_Commerce.Repository.Repository;
using Models.Models;
using System;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Unit
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private bool disposedValue;
        public GenericRepository<User> userRepository;
        public GenericRepository<Admin> adminRepository;
        public GenericRepository<Customer> customerRepository;
        public GenericRepository<Category> categoryRepository;
        public GenericRepository<Order> orderRepository;
        public GenericRepository<OrderDetails> orderDetailsRepository;
        public GenericRepository<Product> productRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
            userRepository = new GenericRepository<User>(_context);
            adminRepository = new GenericRepository<Admin>(_context);
            customerRepository = new GenericRepository<Customer>(_context);
            categoryRepository = new GenericRepository<Category>(_context);
            orderRepository = new GenericRepository<Order>(_context);
            orderDetailsRepository = new GenericRepository<OrderDetails>(_context);
            productRepository = new GenericRepository<Product>(_context);
        }


        public async Task<int> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync();
        }

        public int SaveChanges()
        { 
            return _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}