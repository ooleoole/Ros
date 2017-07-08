using AutoMapper;
using Data.DatabaseModels.CompleteModel;
using Data.Interfaces;
using Domain.Entities;
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
    public abstract class LazyConnectedService<TEntityDTO, TEntityEF> : ILazyConnectedService<TEntityDTO, TEntityEF>
        where TEntityDTO : class where TEntityEF : class, IEntity, new()
    {
        protected readonly ILazyConnectedRepository<TEntityEF> _repo;
        protected readonly Mapper _mapper;

        protected LazyConnectedService()
        {
            var context = new CompleteModel();

            _repo = new ConnectedLazyRepository<TEntityEF>(new Context<TEntityEF>(context, context.Set<TEntityEF>()));
            _mapper = new Mapper(MapperProfiles.InitializeAutoMapper());
        }

        protected LazyConnectedService(ILazyConnectedRepository<TEntityEF> repo)
        {
            _repo = repo;
            _mapper = new Mapper(MapperProfiles.InitializeAutoMapper());
        }

        public virtual IEnumerable<TEntityDTO> GetAll()
        {
            return _repo.GetAll().Select(x => _mapper.DefaultContext.Mapper.Map<TEntityDTO>(x));
        }

        public virtual IEnumerable<TEntityDTO> FindBy(Expression<Func<TEntityEF, bool>> predicate)
        {
            var foundUser = _repo.FindBy(predicate);
            return foundUser.Select(x => _mapper.DefaultContext.Mapper.Map<TEntityDTO>(x));
        }

        public virtual void Dispose()
        {
            _repo.Dispose();
        }

        public abstract void Update(UserDTO caller, TEntityDTO entity);

        public abstract void Add(UserDTO caller, TEntityDTO entity);

        public abstract void Delete(UserDTO caller, TEntityDTO entity);
    }
}