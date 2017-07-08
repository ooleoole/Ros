using System;
using System.Data.Entity;

namespace Domain.Interfaces
{
    public interface IContext<TEntity> : IDisposable where TEntity : class
    {
        DbContext DbContext { get; }
        IDbSet<TEntity> DbSet { get; }
    }
}