using AutoMapper;
using Data.DatabaseModels.CompleteModel;
using Data.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Service;
using Domain.Mappings.Profiles;
using Domain.Repositories;
using Domain.Utilities;
using RefactorThis.GraphDiff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Services.BaseServices
{
    public abstract class EagerDisconnectedService<TEntityDTO, TEntityEF> : IEagerDisconnectedService<TEntityDTO, TEntityEF>
        where TEntityDTO : class where TEntityEF : class, IEntity, new()
    {
        protected readonly IEagerDisconnectedRepository<TEntityEF> _repo;
        protected readonly Mapper _mapper;

        protected EagerDisconnectedService()
        {
            var context = new CompleteModel();
            _repo = new EagerDisconnectedRepository<TEntityEF>(new Context<TEntityEF>(context, context.Set<TEntityEF>()));
            _mapper = new Mapper(MapperProfiles.InitializeAutoMapper());
        }

        protected EagerDisconnectedService(IEagerDisconnectedRepository<TEntityEF> repo)
        {
            _repo = repo;
            _mapper = new Mapper(MapperProfiles.InitializeAutoMapper());
        }

        public virtual IEnumerable<TEntityDTO> GetAll()
        {
            var entityList = _repo.GetAll().Select(x => _mapper.DefaultContext.Mapper.Map<TEntityDTO>(x));
            return entityList;
        }

        public virtual IEnumerable<TEntityDTO> FindBy(Expression<Func<TEntityEF, bool>> predicate)
        {
            var foundEnties = _repo.FindBy(predicate);
            return foundEnties.Select(x => _mapper.DefaultContext.Mapper.Map<TEntityDTO>(x));
        }

        public void Dispose()
        {
            _repo.Dispose();
        }

        public virtual IEnumerable<TEntityDTO> AllInclude(params Expression<Func<TEntityEF, object>>[] includeProperties)
        {
            var foundEntity = _repo.AllInclude(includeProperties);
            return foundEntity.Select(x => _mapper.DefaultContext.Mapper.Map<TEntityDTO>(x));
        }

        public virtual IEnumerable<TEntityDTO> FindByInclude(Expression<Func<TEntityEF, bool>> predicate, params Expression<Func<TEntityEF, object>>[] includeProperties)
        {
            var foundEntity = _repo.FindByInclude(predicate, includeProperties);
            return foundEntity.Select(x => _mapper.DefaultContext.Mapper.Map<TEntityDTO>(x));
        }

        public abstract void Add(UserDTO caller, TEntityDTO entity);

        public abstract void Delete(UserDTO caller, TEntityDTO entity);

        public abstract void Update(UserDTO caller, TEntityDTO entity);

        public abstract void Update(UserDTO caller, TEntityDTO entity,
            Expression<Func<IUpdateConfiguration<TEntityEF>, object>> graph);
    }
}