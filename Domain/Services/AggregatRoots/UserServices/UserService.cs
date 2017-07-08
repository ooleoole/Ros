using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Service;

namespace Domain.Services.AggregatRoots.UserServices
{
    public class UserService : IServiceSelector<UserDTO, User>
    {
        public IEagerDisconnectedService<UserDTO, User> EagerDisconnectedService { get; }
        public ILazyConnectedService<UserDTO, User> LazyConnectedService { get; }
        internal IInternalService<UserDTO, User> InternalService { get; }

        public UserService()
        {
            LazyConnectedService = new LazyConnectedUserService();
            EagerDisconnectedService = new EagerDisconnectedUserService();
            InternalService = new InternalUserService();
        }

        public void Dispose()
        {
            EagerDisconnectedService.Dispose();
            LazyConnectedService.Dispose();
        }
    }
}