using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity.Entity
    {
        TEntity Get(Guid? id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        //
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entity);

        //

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entity);
    }
}
