using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Utilities;
using RefactorThis.GraphDiff;
using System;
using System.Linq.Expressions;

namespace Domain.Services.AggregatRoots.TeamServices
{
    public class EagerDisconnectedTeamService : BaseServices.EagerDisconnectedService<TeamDTO, Team>
    {
        public EagerDisconnectedTeamService()
        {
        }

        public EagerDisconnectedTeamService(IEagerDisconnectedRepository<Team> repo) : base(repo)
        {
        }

        public override void Update(UserDTO caller, TeamDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            entity.CheckPermission(caller);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<Team>(entity);
            _repo.Update(entityToUpdate);
        }

        public override void Update(UserDTO caller, TeamDTO entity, Expression<Func<IUpdateConfiguration<Team>, object>> graph)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            entity.CheckPermission(caller);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<Team>(entity);
            _repo.Update(entityToUpdate, graph);
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