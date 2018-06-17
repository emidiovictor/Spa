using Domain.Entity;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace InfraData.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly Context _dbContext;
        protected Repository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entiteies)
        {
            _dbContext.Set<TEntity>().AddRange(entiteies);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public virtual TEntity Get(Guid? id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()

        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public virtual void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        

        public void RemoveRange(IEnumerable<TEntity> entity)
        {
            _dbContext.Set<TEntity>().RemoveRange(entity);
        }
    }

}
