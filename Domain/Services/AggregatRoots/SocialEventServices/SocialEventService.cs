using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Service;

namespace Domain.Services.AggregatRoots.SocialEventServices
{
    public class SocialEventService : IServiceSelector<SocialEventDTO, SocialEvent>
    {
        public IEagerDisconnectedService<SocialEventDTO, SocialEvent> EagerDisconnectedService { get; }
        public ILazyConnectedService<SocialEventDTO, SocialEvent> LazyConnectedService { get; }

        public SocialEventService()
        {
            LazyConnectedService = new LazyConnectedSocialEventService();
            EagerDisconnectedService = new EagerDisconnectedSocialEventService();
        }

        public void Dispose()
        {
            EagerDisconnectedService.Dispose();
            LazyConnectedService.Dispose();
        }
    }
}