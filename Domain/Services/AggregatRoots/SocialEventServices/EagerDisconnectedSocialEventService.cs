using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Utilities;
using RefactorThis.GraphDiff;
using System;
using System.Linq.Expressions;

namespace Domain.Services.AggregatRoots.SocialEventServices
{
    public class EagerDisconnectedSocialEventService : BaseServices.EagerDisconnectedService<SocialEventDTO, SocialEvent>
    {
        public EagerDisconnectedSocialEventService()
        {
        }

        public EagerDisconnectedSocialEventService(IEagerDisconnectedRepository<SocialEvent> repo) : base(repo)
        {
        }

        public override void Update(UserDTO caller, SocialEventDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller);
            entity.CheckPermission(caller);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<SocialEvent>(entity);
            _repo.Update(entityToUpdate);
        }

        public override void Update(UserDTO caller, SocialEventDTO entity, Expression<Func<IUpdateConfiguration<SocialEvent>, object>> graph)
        {
            NullCheck.ThrowArgumentNullEx(caller);
            entity.CheckPermission(caller);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<SocialEvent>(entity);
            _repo.Update(entityToUpdate, graph);
        }

        public override void Add(UserDTO caller, SocialEventDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(entity);
            entity.CheckPermissionToAffiliatedRegatta(caller);
            var entityToAdd = _mapper.DefaultContext.Mapper.Map<SocialEvent>(entity);
            _repo.Add(entityToAdd);
        }

        public override void Delete(UserDTO caller, SocialEventDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller);
            entity.CheckPermission(caller);
            var entityToDelete = _mapper.DefaultContext.Mapper.Map<SocialEvent>(entity);
            _repo.Delete(entityToDelete);
        }
    }
}