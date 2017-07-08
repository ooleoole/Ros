using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Service;

namespace Domain.Services.AddressServices
{
    public class AddressService : IServiceSelector<AddressDTO, Address>
    {
        public IEagerDisconnectedService<AddressDTO, Address> EagerDisconnectedService { get; }
        public ILazyConnectedService<AddressDTO, Address> LazyConnectedService { get; }

        public AddressService()
        {
            LazyConnectedService = new LazyConnectedAddressService();
            EagerDisconnectedService = new EagerDisconnectedAddressService();
        }

        public void Dispose()
        {
            EagerDisconnectedService.Dispose();
            LazyConnectedService.Dispose();
        }
    }
}