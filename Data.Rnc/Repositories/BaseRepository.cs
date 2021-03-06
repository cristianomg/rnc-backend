﻿using Data.Rnc.Context;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
        public async Task<IQueryable<TEntity>> GetAll() => 
            await Task.FromResult(_dbSet.AsQueryable());
        public async Task<IQueryable<TEntity>> GetAll
            (Expression<Func<TEntity, bool>> query) =>
            await Task.FromResult(_dbSet.Where(query).AsQueryable());
        public async Task<IQueryable<TEntity>> GetAllWithIncludes
            (params string[] includes)
        {
            var result = _dbSet.AsQueryable();
            foreach (var i in includes)
            {
                result = result.Include(i);
            }
            return await Task.FromResult(result);
        }
        public async Task<IQueryable<TEntity>> GetAllWithIncludes
            (Expression<Func<TEntity, bool>> query, params string[] includes)
        {
            var result = _dbSet.Where(query).AsQueryable();
            foreach (var i in includes)
            {
                result = result.Include(i);
            }
            return await Task.FromResult(result);
        }
        public async Task<TEntity> GetById(int id) => 
            await _dbSet.FindAsync(id);
        public async Task<TEntity> Insert(TEntity obj)
        {
            var entity = await _dbSet.AddAsync(obj);
            return entity.Entity;
        }
        public async Task<TEntity> Update(TEntity obj) =>
            await Task.FromResult(_dbSet.Update(obj).Entity);

        public async Task<int> SaveChanges() => 
            await _context.SaveChangesAsync();


    }
}
