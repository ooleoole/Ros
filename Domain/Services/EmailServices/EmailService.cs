using Data.DatabaseModels.CompleteModel;
using Domain.Entities;
using Domain.Interfaces.Service;

namespace Domain.Services.EmailServices
{
    public class EmailService : IServiceSelector<EmailDTO, Email>
    {
        public IEagerDisconnectedService<EmailDTO, Email> EagerDisconnectedService { get; }
        public ILazyConnectedService<EmailDTO, Email> LazyConnectedService { get; }
        internal IInternalService<EmailDTO, Email> InternalService { get; }

        public EmailService()
        {
            LazyConnectedService = new LazyConnectedEmailService();
            EagerDisconnectedService = new EagerDisconnectedEmailService();
            InternalService = new InternalEmailService();
        }

        public void Dispose()
        {
            EagerDisconnectedService.Dispose();
            LazyConnectedService.Dispose();
            InternalService.Dispose();
        }
    }
}