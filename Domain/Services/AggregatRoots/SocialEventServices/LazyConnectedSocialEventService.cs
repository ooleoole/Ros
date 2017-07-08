using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Utilities;

namespace Domain.Services.AggregatRoots.SocialEventServices
{
    public class LazyConnectedSocialEventService : BaseServices.LazyConnectedService<SocialEventDTO, SocialEvent>
    {
        public LazyConnectedSocialEventService()
        {
        }

        public LazyConnectedSocialEventService(ILazyConnectedRepository<SocialEvent> repo) : base(repo)
        {
        }

        public override void Update(UserDTO caller, SocialEventDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller);
            entity.CheckPermission(caller);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<SocialEvent>(entity);
            _repo.Update(entityToUpdate);
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