using AutoMapper;
using Data.DatabaseModels.CompleteModel;
using Data.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Service;
using Domain.Mappings.Profiles;
using Domain.Repositories;
using Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Services.BaseServices
{
    internal abstract class InternalService<TEntityDTO, TEntityEF> : IInternalService<TEntityDTO, TEntityEF>
        where TEntityDTO : class where TEntityEF : class, IEntity, new()
    {
        private readonly IEagerDisconnectedRepository<TEntityEF> _repo;
        private readonly Mapper _mapper;

        internal InternalService()
        {
            _mapper = new Mapper(MapperProfiles.InitializeAutoMapper());
            var context = new CompleteModel();
            _repo = new EagerDisconnectedRepository<TEntityEF>(new Context<TEntityEF>(context, context.Set<TEntityEF>()));
        }

        public virtual IEnumerable<TEntityDTO> FindBy(Expression<Func<TEntityEF, bool>> predicate)
        {
            var foundEnties = _repo.FindBy(predicate);
            return foundEnties.Select(x => _mapper.DefaultContext.Mapper.Map<TEntityDTO>(x));
        }

        public virtual void Add(TEntityDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(entity);

            var entityToAdd = _mapper.DefaultContext.Mapper.Map<TEntityEF>(entity);
            _repo.Add(entityToAdd);
        }

        public virtual void Delete(TEntityDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(entity);

            var entityToDelete = _mapper.DefaultContext.Mapper.Map<TEntityEF>(entity);
            _repo.Delete(entityToDelete);
        }

        public void Dispose()
        {
            _repo.Dispose();
        }

        public virtual void Update(TEntityDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(entity);

            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<TEntityEF>(entity);
            _repo.Update(entityToUpdate);
        }
    }
}