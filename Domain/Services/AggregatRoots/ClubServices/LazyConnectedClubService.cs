using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces.Repositories;
using Domain.Services.Locator;
using Domain.Utilities;
using System.Linq;

namespace Domain.Services.AggregatRoots.ClubServices
{
    public class LazyConnectedClubService : BaseServices.LazyConnectedService<ClubDTO, Club>
    {
        public LazyConnectedClubService()
        {
        }

        public LazyConnectedClubService(ILazyConnectedRepository<Club> repo) : base(repo)
        {
        }

        public override void Add(UserDTO caller, ClubDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(entity);
            var entityToAdd = _mapper.DefaultContext.Mapper.Map<Club>(entity);
            _repo.Add(entityToAdd);
            MakeCallerAdminForClub(caller, entity);
        }

        public override void Delete(UserDTO caller, ClubDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            entity.CheckPermission(caller);
            var entityToDelete = _mapper.DefaultContext.Mapper.Map<Club>(entity);
            _repo.Delete(entityToDelete);
        }

        public override void Update(UserDTO caller, ClubDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            entity.CheckPermission(caller);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<Club>(entity);
            _repo.Update(entityToUpdate);
        }

        private static void MakeCallerAdminForClub(UserDTO caller, ClubDTO entity)
        {
            var club = ServiceLocator.ClubService.EagerDisconnectedService.FindBy(
                    c => c.Name == entity.Name)
                .First();
            var relation = club.RoleHandler.GetRoleRelation(caller, Role.Admin);
            club.RoleHandler.AddRoleRelationToDb(relation);
        }
    }
}