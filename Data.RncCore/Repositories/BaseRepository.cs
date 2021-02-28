using Data.Rnc.Context;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Rnc.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly RncContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public BaseRepository(RncContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public IQueryable<TEntity> GetAll() => 
            _dbSet.AsQueryable();
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> query) =>
            _dbSet.Where(query).AsQueryable();
        public IQueryable<TEntity> GetAllWithIncludes(params string[] includes)
        {
            var result = _dbSet.AsQueryable();
            foreach (var i in includes)
            {
                result = result.Include(i);
            }
            return result;
        }
        public IQueryable<TEntity> GetAllWithIncludes(Expression<Func<TEntity, bool>> query, params string[] includes)
        {
            var result = _dbSet.Where(query).AsQueryable();
            foreach (var i in includes)
            {
                result = result.Include(i);
            }
            return result;
        }
        public TEntity GetById(int id) => 
            _dbSet.Find(id);
        public TEntity Insert(TEntity obj) => 
            _dbSet.Add(obj).Entity;
        public TEntity Update(TEntity obj) => 
            _dbSet.Update(obj).Entity;
        public int SaveChanges() => 
            _context.SaveChanges();


    }
}
