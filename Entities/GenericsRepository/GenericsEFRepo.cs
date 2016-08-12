using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Entities.GenericsRepository
{
    public abstract class GenericsEFRepo<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext context;

        public GenericsEFRepo(DbContext newContext)
        {
            context = newContext;
        }

        public void Delete(TEntity entityToDelete)
        {
            context.Set<TEntity>().Remove(entityToDelete);
            context.Entry<TEntity>(entityToDelete).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            TEntity entiryToDelete = GetById(id);
            if (entiryToDelete == null)
                return;
            Delete(entiryToDelete);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return GetAll().Where(filter);
        }

        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public abstract TEntity GetById(int id);


        public virtual void Insert(TEntity newEntity)
        {
            context.Set<TEntity>().Add(newEntity);
            context.Entry<TEntity>(newEntity).State = EntityState.Added;
            context.SaveChanges();

        }
    }
    
}
