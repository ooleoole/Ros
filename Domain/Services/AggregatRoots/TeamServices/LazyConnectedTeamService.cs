using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Utilities;

namespace Domain.Services.AggregatRoots.TeamServices
{
    public class LazyConnectedTeamService : BaseServices.LazyConnectedService<TeamDTO, Team>
    {
        public LazyConnectedTeamService()
        {
        }

        public LazyConnectedTeamService(ILazyConnectedRepository<Team> repo) : base(repo)
        {
        }

        public override void Update(UserDTO caller, TeamDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            entity.CheckPermission(caller);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<Team>(entity);
            _repo.Update(entityToUpdate);
        }

        public override void Add(UserDTO caller, TeamDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            entity.CheckPermissionToAffiliatedEntry(caller);
            var entityToAdd = _mapper.DefaultContext.Mapper.Map<Team>(entity);
            _repo.Add(entityToAdd);
        }

        public override void Delete(UserDTO caller, TeamDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            entity.CheckPermission(caller);
            var entityToDelete = _mapper.DefaultContext.Mapper.Map<Team>(entity);
            _repo.Delete(entityToDelete);
        }
    }
}