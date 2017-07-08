using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Utilities;

namespace Domain.Services.AggregatRoots.RegattaServices
{
    public class LazyConnectedRegattaService : BaseServices.LazyConnectedService<RegattaDTO, Regatta>
    {
        public LazyConnectedRegattaService()
        {
        }

        public LazyConnectedRegattaService(ILazyConnectedRepository<Regatta> repo) : base(repo)
        {
        }

        public override void Update(UserDTO caller, RegattaDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller);
            entity.CheckPermission(caller);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<Regatta>(entity);
            _repo.Update(entityToUpdate);
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