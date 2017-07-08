using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Service;

namespace Domain.Services.AggregatRoots.RegattaServices
{
    public class RegattaService : IServiceSelector<RegattaDTO, Regatta>
    {
        public IEagerDisconnectedService<RegattaDTO, Regatta> EagerDisconnectedService { get; }
        public ILazyConnectedService<RegattaDTO, Regatta> LazyConnectedService { get; }

        public RegattaService()
        {
            LazyConnectedService = new LazyConnectedRegattaService();
            EagerDisconnectedService = new EagerDisconnectedRegattaService();
        }

        public void Dispose()
        {
            EagerDisconnectedService.Dispose();
            LazyConnectedService.Dispose();
        }
    }
}