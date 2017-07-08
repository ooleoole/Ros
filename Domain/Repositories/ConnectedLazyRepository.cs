using Data.Interfaces;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Domain.Repositories
{
    public class ConnectedLazyRepository<TEntity> : ILazyConnectedRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly IContext<TEntity> _context;

        public ConnectedLazyRepository(IContext<TEntity> context)
        {
            if (context is null) throw new ArgumentNullException(nameof(context));
            _context = context;
            _context.DbContext.Configuration.LazyLoadingEnabled = true;
        }

        public void Add(TEntity entity)
        {
            _context.DbSet.Add(entity);
            _context.DbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            entity.Active = false;
            Update(entity);
            //_context.DbSet.Remove(entity);
            //_context.DbContext.SaveChanges();
        }

        public IEnumerable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> results = _context.DbSet.Where(predicate).ToList();
            return results;
        }

        public TEntity FindByKey(int id)
        {
            return _context.DbSet.SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.DbSet;
        }

        public void Update(TEntity entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            _context.DbSet.Attach(entity);
            _context.DbContext.Entry(entity).State = EntityState.Modified;
            _context.DbContext.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}