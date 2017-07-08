using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Utilities;

namespace Domain.Services.ResultServices
{
    public class LazyConnectedResultService : BaseServices.LazyConnectedService<ResultDTO, Result>
    {
        public LazyConnectedResultService()
        {
        }

        public LazyConnectedResultService(ILazyConnectedRepository<Result> repo) : base(repo)
        {
        }

        public override void Add(UserDTO caller, ResultDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(entity);
            entity.CheckPermissionToAffiliatedRaceEvent(caller);
            var entityToAdd = _mapper.DefaultContext.Mapper.Map<Result>(entity);
            _repo.Add(entityToAdd);
        }

        public override void Delete(UserDTO caller, ResultDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(entity);
            entity.CheckPermission(caller);
            var entityToDelete = _mapper.DefaultContext.Mapper.Map<Result>(entity);
            _repo.Delete(entityToDelete);
        }

        public override void Update(UserDTO caller, ResultDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(entity);
            entity.CheckPermission(caller);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<Result>(entity);
            _repo.Update(entityToUpdate);
        }
    }
}