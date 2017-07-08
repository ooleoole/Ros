using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Service;

namespace Domain.Services.AggregatRoots.RaceEventServices
{
    public class RaceEventService : IServiceSelector<RaceEventDTO, RaceEvent>
    {
        public IEagerDisconnectedService<RaceEventDTO, RaceEvent> EagerDisconnectedService { get; }
        public ILazyConnectedService<RaceEventDTO, RaceEvent> LazyConnectedService { get; }

        public RaceEventService()
        {
            LazyConnectedService = new LazyConnectedRaceEventService();
            EagerDisconnectedService = new EagerDisconnectedRaceEventService();
        }

        public void Dispose()
        {
            EagerDisconnectedService.Dispose();
            LazyConnectedService.Dispose();
        }
    }
}