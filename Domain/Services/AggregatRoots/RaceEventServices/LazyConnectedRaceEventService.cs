using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Utilities;

namespace Domain.Services.AggregatRoots.RaceEventServices
{
    public class LazyConnectedRaceEventService : BaseServices.LazyConnectedService<RaceEventDTO, RaceEvent>
    {
        public LazyConnectedRaceEventService()
        {
        }

        public LazyConnectedRaceEventService(ILazyConnectedRepository<RaceEvent> repo) : base(repo)
        {
        }

        public override void Update(UserDTO caller, RaceEventDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller);
            entity.CheckPermission(caller);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<RaceEvent>(entity);
            _repo.Update(entityToUpdate);
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