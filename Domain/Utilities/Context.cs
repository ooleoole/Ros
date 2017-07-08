using Domain.Interfaces;
using System.Data.Entity;

namespace Domain.Utilities
{
    public class Context<TEntity> : IContext<TEntity> where TEntity : class
    {
        public DbContext DbContext { get; }
        public IDbSet<TEntity> DbSet { get; }

        public Context(DbContext context, IDbSet<TEntity> dbSet)
        {
            DbContext = context;
            DbSet = dbSet;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}