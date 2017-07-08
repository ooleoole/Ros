using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Utilities;
using RefactorThis.GraphDiff;
using System;
using System.Linq.Expressions;

namespace Domain.Services.AggregatRoots.RegattaServices
{
    public class EagerDisconnectedRegattaService : BaseServices.EagerDisconnectedService<RegattaDTO, Regatta>
    {
        public EagerDisconnectedRegattaService()
        {
        }

        public EagerDisconnectedRegattaService(IEagerDisconnectedRepository<Regatta> repo) : base(repo)
        {
        }

        public override void Update(UserDTO caller, RegattaDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller);
            entity.CheckPermission(caller);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<Regatta>(entity);
            _repo.Update(entityToUpdate);
        }

        public override void Update(UserDTO caller, RegattaDTO entity, Expression<Func<IUpdateConfiguration<Regatta>, object>> graph)
        {
            NullCheck.ThrowArgumentNullEx(caller);
            entity.CheckPermission(caller);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<Regatta>(entity);
            _repo.Update(entityToUpdate, graph);
        }

        public override void Add(UserDTO caller, RegattaDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(entity);
            entity.CheckPermissionToAffiliatedClub(caller);
            var entityToAdd = _mapper.DefaultContext.Mapper.Map<Regatta>(entity);
            _repo.Add(entityToAdd);
        }

        public override void Delete(UserDTO caller, RegattaDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller);
            entity.CheckPermission(caller);
            var entityToDelete = _mapper.DefaultContext.Mapper.Map<Regatta>(entity);
            _repo.Delete(entityToDelete);
        }
    }
}