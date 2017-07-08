using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Utilities;

namespace Domain.Services.PhoneNumberServices
{
    public class LazyConnectedPhoneNumberService : BaseServices.LazyConnectedService<PhoneNumberDTO, PhoneNumber>
    {
        public LazyConnectedPhoneNumberService()
        {
        }

        public LazyConnectedPhoneNumberService(ILazyConnectedRepository<PhoneNumber> repo) : base(repo)
        {
        }

        public override void Add(UserDTO caller, PhoneNumberDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<PhoneNumber>(entity);
            _repo.Update(entityToUpdate);
        }

        public override void Delete(UserDTO caller, PhoneNumberDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            var entityToDelete = _mapper.DefaultContext.Mapper.Map<PhoneNumber>(entity);
            _repo.Delete(entityToDelete);
        }

        public override void Update(UserDTO caller, PhoneNumberDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(caller, entity);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<PhoneNumber>(entity);
            _repo.Update(entityToUpdate);
        }
    }
}