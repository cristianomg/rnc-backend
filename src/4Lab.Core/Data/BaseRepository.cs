using _4Lab.Core.Audit;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace _4Lab.Core.Data
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<IQueryable<TEntity>> GetAll() => await Task.FromResult(_dbSet.AsQueryable());

        public async Task<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>> query) =>
            await Task.FromResult(_dbSet.Where(query).AsQueryable());

        public async Task<IQueryable<TEntity>> GetAllWithIncludes(params string[] includes)
        {
            var result = _dbSet.AsQueryable();

            foreach (var i in includes)
            {
                result = result.Include(i);
            }

            return await Task.FromResult(result);
        }

        public async Task<IQueryable<TEntity>> GetAllWithIncludes(Expression<Func<TEntity, bool>> query, params string[] includes)
        {
            var result = _dbSet.Where(query).AsQueryable();

            foreach (var i in includes)
            {
                result = result.Include(i);
            }

            return await Task.FromResult(result);
        }

        public async Task<TEntity> GetById(TKey id) => await _dbSet.FindAsync(id);

        public async Task<TEntity> Insert(TEntity obj)
        {
            var entity = await _dbSet.AddAsync(obj);
            return entity.Entity;
        }

        public async Task InsertMany(IEnumerable<TEntity> objs) => await _dbSet.AddRangeAsync(objs);

        public async Task<TEntity> Update(TEntity obj) => await Task.FromResult(_dbSet.Update(obj).Entity);

        public async Task<int> SaveChanges()
        {
            var historics = new List<Historic>();

            foreach (var entry in _context.ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
                    entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedAt").IsModified = false;
                    entry.Property("CreatedBy").IsModified = false;
                    entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                }

                var entity = entry.Entity;
                historics.Add(CreateHistoric(entity));
            }

            var historyDb = _context.Set<Historic>();
            historyDb.AddRange(historics);

            return await _context.SaveChangesAsync();
        }

        private Historic CreateHistoric(object entity)
        {
            var json = JsonConvert.SerializeObject(entity, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return new Historic()
            {
                Entity = entity.ToString(),
                Values = json
            };
        }
    }
}
