using System;
using System.Linq;
using System.Linq.Expressions;

namespace Entities.GenericsRepository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Insert(TEntity newEntity);
        void Delete(int id);
        void Delete(TEntity entityToDelete);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);
    }
}
