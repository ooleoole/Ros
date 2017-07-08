using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Service;

namespace Domain.Services.AggregatRoots.TeamServices
{
    public class TeamService : IServiceSelector<TeamDTO, Team>
    {
        public IEagerDisconnectedService<TeamDTO, Team> EagerDisconnectedService { get; }
        public ILazyConnectedService<TeamDTO, Team> LazyConnectedService { get; }
        internal IInternalService<TeamDTO, Team> InternalService { get; }

        public TeamService()
        {
            LazyConnectedService = new LazyConnectedTeamService();
            EagerDisconnectedService = new EagerDisconnectedTeamService();
            InternalService = new InternalTeamService();
        }

        public void Dispose()
        {
            EagerDisconnectedService.Dispose();
            LazyConnectedService.Dispose();
            InternalService.Dispose();
        }
    }
}