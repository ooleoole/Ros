using RefactorThis.GraphDiff;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfaces.Repositories
{
    public interface IEagerDisconnectedRepository<TEntityEF> : IRepository<TEntityEF> where TEntityEF : class
    {
        IEnumerable<TEntityEF> AllInclude(params Expression<Func<TEntityEF, object>>[] includeProperties);

        void Update(TEntityEF entity, Expression<Func<IUpdateConfiguration<TEntityEF>, object>> graph);

        IEnumerable<TEntityEF> FindByInclude(Expression<Func<TEntityEF, bool>> predicate,
            params Expression<Func<TEntityEF, object>>[] includeProperties);
    }
}