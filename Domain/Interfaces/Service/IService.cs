using Data.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfaces.Service
{
    public interface IService<TEntityDTO, TEfEntity> where TEntityDTO : class where TEfEntity : IEntity
    {
        void Update(UserDTO caller, TEntityDTO entity);

        void Add(UserDTO caller, TEntityDTO entity);

        void Delete(UserDTO caller, TEntityDTO entity);

        IEnumerable<TEntityDTO> GetAll();

        IEnumerable<TEntityDTO> FindBy(Expression<Func<TEfEntity, bool>> predicate);

        void Dispose();
    }
}