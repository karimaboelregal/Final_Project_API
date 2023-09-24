
using E_Commerce.Data.Context;
using E_Commerce.Repository.Interface;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Models.Models;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Repository.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DataContext _context;
        public GenericRepository(DataContext context) { 
        _context = context;
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            return _context.Set<TEntity>().Add(entity).Entity;
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public virtual void Attach(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
        }

        public virtual Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual  void Update(TEntity entity)
        {
             _context.Set<TEntity>().Update(entity);
        }
        public async Task<IEnumerable<TEntity>> GetAllWithInclude(Expression<Func<TEntity, bool>> predicate = null, string include)
        {

            return await _context.Set<TEntity>().Where(predicate).Include(include).ToListAsync();
        }

    }
}
