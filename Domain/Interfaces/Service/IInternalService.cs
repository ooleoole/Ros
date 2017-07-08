using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfaces.Service
{
    internal interface IInternalService<TEntityDTO, TEntityEF> where TEntityDTO : class where TEntityEF : IEntity
    {
        IEnumerable<TEntityDTO> FindBy(Expression<Func<TEntityEF, bool>> predicate);

        void Update(TEntityDTO entity);

        void Add(TEntityDTO entity);

        void Delete(TEntityDTO entity);

        void Dispose();
    }
}