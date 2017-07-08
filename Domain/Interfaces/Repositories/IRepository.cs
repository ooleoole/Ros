using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        void Delete(TEntity entity);

        TEntity FindByKey(int id);

        IEnumerable<TEntity> GetAll();

        void Dispose();
    }
}