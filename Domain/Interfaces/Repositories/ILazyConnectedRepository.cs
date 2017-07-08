namespace Domain.Interfaces.Repositories
{
    public interface ILazyConnectedRepository<TEntityEF> : IRepository<TEntityEF>
        where TEntityEF : class
    {
    }
}