using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{

    public interface IBaseRepository<TEntity, TKey> where TEntity : class                                                                          
    {
        Task<IQueryable<TEntity>> GetAll();
        Task<IQueryable<TEntity>> GetAllWithIncludes(params string[] includes);
        Task<IQueryable<TEntity>> GetAll(Expression<Func<TEntity, bool>> query);
        Task<IQueryable<TEntity>> GetAllWithIncludes(Expression<Func<TEntity, bool>> query, params string[] includes);
        Task<TEntity> GetById(TKey id);
        Task<TEntity> Insert(TEntity obj);
        Task InsertMany(IEnumerable<TEntity> objs);
        Task<TEntity> Update(TEntity obj);
        Task<int> SaveChanges();
    }
}
