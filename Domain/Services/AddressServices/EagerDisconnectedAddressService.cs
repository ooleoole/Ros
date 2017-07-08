using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Utilities;
using RefactorThis.GraphDiff;
using System.Linq.Expressions;

namespace Domain.Services.AddressServices
{
    public class EagerDisconnectedAddressService : BaseServices.EagerDisconnectedService<AddressDTO, Address>
    {
        public EagerDisconnectedAddressService()
        {
        }

        public EagerDisconnectedAddressService(IEagerDisconnectedRepository<Address> repo) : base(repo)
        {
        }

        public override void Update(UserDTO caller, AddressDTO entity)
        {
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<Address>(entity);
            _repo.Update(entityToUpdate);
        }

        public override void Update(UserDTO caller, AddressDTO entity, Expression<System.Func<IUpdateConfiguration<Address>, object>> graph)
        {
            NullCheck.ThrowArgumentNullEx(entity);
            var entityToUpdate = _mapper.DefaultContext.Mapper.Map<Address>(entity);
            _repo.Update(entityToUpdate, graph);
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