using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Service;

namespace Domain.Services.ResultServices
{
    public class ResultService : IServiceSelector<ResultDTO, Result>
    {
        public IEagerDisconnectedService<ResultDTO, Result> EagerDisconnectedService { get; }
        public ILazyConnectedService<ResultDTO, Result> LazyConnectedService { get; }

        public ResultService()
        {
            LazyConnectedService = new LazyConnectedResultService();
            EagerDisconnectedService = new EagerDisconnectedResultService();
        }

        public void Dispose()
        {
            EagerDisconnectedService.Dispose();
            LazyConnectedService.Dispose();
        }
    }
}