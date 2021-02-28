using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{

    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllWithIncludes(params string[] includes);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> query);
        IQueryable<TEntity> GetAllWithIncludes(Expression<Func<TEntity, bool>> query, params string[] includes);
        TEntity GetById(int id);
        TEntity Insert(TEntity obj);
        TEntity Update(TEntity obj);
        int SaveChanges();
    }
}
