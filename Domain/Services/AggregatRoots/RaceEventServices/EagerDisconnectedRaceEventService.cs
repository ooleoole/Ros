using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Utilities;
using RefactorThis.GraphDiff;
using System;
using System.Linq.Expressions;

namespace Domain.Services.AggregatRoots.RaceEventServices
{
    public class EagerDisconnectedRaceEventService : BaseServices.EagerDisconnectedService<RaceEventDTO, RaceEvent>
    {
        public EagerDisconnectedRaceEventService()
        {
        }

        public EagerDisconnectedRaceEventService(IEagerDisconnectedRepository<RaceEvent> repo) : base(repo)
        {
        }

        public override void Update(UserDTO caller, RaceEventDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller);
            entity.CheckPermission(caller);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<RaceEvent>(entity);
            _repo.Update(entityToUpdate);
        }

        public override void Update(UserDTO caller, RaceEventDTO entity, Expression<Func<IUpdateConfiguration<RaceEvent>, object>> graph)
        {
            NullCheck.ThrowArgumentNullEx(caller);
            entity.CheckPermission(caller);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<RaceEvent>(entity);
            _repo.Update(entityToUpdate, graph);
        }

        public override void Add(UserDTO caller, RaceEventDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller);
            entity.CheckPermissionToAffiliatedRegatta(caller);
            var entityToAdd = _mapper.DefaultContext.Mapper.Map<RaceEvent>(entity);
            _repo.Add(entityToAdd);
        }

        public override void Delete(UserDTO caller, RaceEventDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller);
            entity.CheckPermission(caller);
            var entityToDelete = _mapper.DefaultContext.Mapper.Map<RaceEvent>(entity);
            _repo.Delete(entityToDelete);
        }
    }
}