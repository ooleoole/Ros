using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Service;

namespace Domain.Services.BoatServices
{
    public class BoatService : IServiceSelector<BoatDTO, Boat>
    {
        public IEagerDisconnectedService<BoatDTO, Boat> EagerDisconnectedService { get; }
        public ILazyConnectedService<BoatDTO, Boat> LazyConnectedService { get; }

        public BoatService()
        {
            LazyConnectedService = new LazyConnectedBoatService();
            EagerDisconnectedService = new EagerDisconnectedClubService();
        }

        public void Dispose()
        {
            EagerDisconnectedService.Dispose();
            LazyConnectedService.Dispose();
        }
    }
}