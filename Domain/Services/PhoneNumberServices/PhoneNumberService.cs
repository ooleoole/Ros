using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Service;

namespace Domain.Services.PhoneNumberServices
{
    public class PhoneNumberService : IServiceSelector<PhoneNumberDTO, PhoneNumber>
    {
        public IEagerDisconnectedService<PhoneNumberDTO, PhoneNumber> EagerDisconnectedService { get; }
        public ILazyConnectedService<PhoneNumberDTO, PhoneNumber> LazyConnectedService { get; }
        internal IInternalService<PhoneNumberDTO, PhoneNumber> InternalService { get; }

        public PhoneNumberService()
        {
            LazyConnectedService = new LazyConnectedPhoneNumberService();
            EagerDisconnectedService = new EagerDisconnectedPhoneNumberService();
            InternalService = new InternalPhoneNumberService();
        }

        public void Dispose()
        {
            EagerDisconnectedService.Dispose();
            LazyConnectedService.Dispose();
            InternalService.Dispose();
        }
    }
}