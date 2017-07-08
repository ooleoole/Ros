using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Services.Locator;
using Domain.Utilities;
using System.Linq;

namespace Domain.Services.AggregatRoots.EntryServices
{
    public class LazyConnectedEntryService : BaseServices.LazyConnectedService<EntryDTO, Entry>
    {
        public LazyConnectedEntryService()
        {
        }

        public LazyConnectedEntryService(ILazyConnectedRepository<Entry> repo) : base(repo)
        {
        }

        public override void Add(UserDTO caller, EntryDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(entity);

            MakeCallerResponsiblePersonForEntry(caller, entity);
            var entityToAdd = _mapper.DefaultContext.Mapper.Map<Entry>(entity);
            _repo.Add(entityToAdd);
            AddResponsibleUserToRegisterdUser(entity);
        }

        public override void Delete(UserDTO caller, EntryDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(entity);
            entity.CheckPermission(caller);
            var entityToDelete = _mapper.DefaultContext.Mapper.Map<Entry>(entity);
            _repo.Delete(entityToDelete);
        }

        public override void Update(UserDTO caller, EntryDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(entity);
            entity.CheckPermission(caller);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<Entry>(entity);
            _repo.Update(entityToUpdate);
        }

        private static void AddResponsibleUserToRegisterdUser(EntryDTO entity)
        {
            var entry = ServiceLocator.EntryService.EagerDisconnectedService.FindBy(
                e => e.EntryNo == entity.EntryNo).First();
            var user = ServiceLocator.UserService.EagerDisconnectedService.FindBy(
                    u => u.Id == entry.ResponsibleUserId)
                .FirstOrDefault();
            entry.AddUserToEntry(user, user);
        }

        private static void MakeCallerResponsiblePersonForEntry(UserDTO caller, EntryDTO entity)
        {
            entity.ResponsibleUserId = entity.ResponsibleUserId == caller.Id ? entity.ResponsibleUserId : caller.Id;
        }
    }
}