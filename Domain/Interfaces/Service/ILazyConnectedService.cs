using Data.Interfaces;

namespace Domain.Interfaces.Service
{
    public interface ILazyConnectedService<TEntityDTO, TEntityEF> : IService<TEntityDTO, TEntityEF>
        where TEntityDTO : class where TEntityEF : class, IEntity, new()
    {
    }
}