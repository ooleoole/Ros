using Data.Interfaces;
using System;

namespace Domain.Interfaces.Service
{
    public interface IServiceSelector<TEntityDTO, TEntityEF> : IDisposable where TEntityDTO : class where TEntityEF : class, IEntity, new()
    {
        IEagerDisconnectedService<TEntityDTO, TEntityEF> EagerDisconnectedService { get; }
        ILazyConnectedService<TEntityDTO, TEntityEF> LazyConnectedService { get; }
    }
}