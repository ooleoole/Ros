using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Utilities;

namespace Domain.Services.AddressServices
{
    public class LazyConnectedAddressService : BaseServices.LazyConnectedService<AddressDTO, Address>
    {
        public LazyConnectedAddressService()
        {
        }

        public LazyConnectedAddressService(ILazyConnectedRepository<Address> repo) : base(repo)
        {
        }

        public override void Update(UserDTO caller, AddressDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(entity);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<Address>(entity);
            _repo.Update(entityToUpdate);
        }

        public override void Add(UserDTO caller, AddressDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(entity);

            var entityToAdd = _mapper.DefaultContext.Mapper.Map<Address>(entity);
            _repo.Add(entityToAdd);
        }

        public override void Delete(UserDTO caller, AddressDTO entity)
        {
            NullCheck.ThrowArgumentNullEx(entity);
            var entityToDelete = _mapper.DefaultContext.Mapper.Map<Address>(entity);
            _repo.Delete(entityToDelete);
        }
    }
}