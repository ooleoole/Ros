using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Service;

namespace Domain.Services.AggregatRoots.EntryServices
{
    public class EntryService : IServiceSelector<EntryDTO, Entry>
    {
        public IEagerDisconnectedService<EntryDTO, Entry> EagerDisconnectedService { get; }
        public ILazyConnectedService<EntryDTO, Entry> LazyConnectedService { get; }

        public EntryService()
        {
            LazyConnectedService = new LazyConnectedEntryService();
            EagerDisconnectedService = new EagerDisconnectedEntryService();
        }

        public void Dispose()
        {
            EagerDisconnectedService.Dispose();
            LazyConnectedService.Dispose();
        }
    }
}