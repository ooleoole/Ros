using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Service;

namespace Domain.Services.AggregatRoots.ClubServices
{
    public class ClubService : IServiceSelector<ClubDTO, Club>
    {
        public IEagerDisconnectedService<ClubDTO, Club> EagerDisconnectedService { get; }
        public ILazyConnectedService<ClubDTO, Club> LazyConnectedService { get; }

        public ClubService()
        {
            LazyConnectedService = new LazyConnectedClubService();
            EagerDisconnectedService = new EagerDisconnectedClubService();
        }

        public void Dispose()
        {
            EagerDisconnectedService.Dispose();
            LazyConnectedService.Dispose();
        }
    }
}