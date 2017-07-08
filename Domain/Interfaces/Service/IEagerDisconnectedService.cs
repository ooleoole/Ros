using Data.Interfaces;
using Domain.Entities;
using RefactorThis.GraphDiff;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfaces.Service
{
    public interface IEagerDisconnectedService<TEntityDTO, TEntityEF> : IService<TEntityDTO, TEntityEF>
        where TEntityDTO : class where TEntityEF : class, IEntity, new()
    {
        IEnumerable<TEntityDTO> FindByInclude(Expression<Func<TEntityEF, bool>> predicate,
            params Expression<Func<TEntityEF, object>>[] includeProperties);

        void Update(UserDTO caller, TEntityDTO entity, Expression<Func<IUpdateConfiguration<TEntityEF>, object>> graph);

        IEnumerable<TEntityDTO> AllInclude(params Expression<Func<TEntityEF, object>>[] includeProperties);
    }
}