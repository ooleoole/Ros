using Data.Interfaces;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using RefactorThis.GraphDiff;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public class EagerDisconnectedRepository<TEntity> : IEagerDisconnectedRepository<TEntity>
        where TEntity : class, IEntity, new()

    {
        private readonly IContext<TEntity> _context;

        public EagerDisconnectedRepository(IContext<TEntity> context)
        {
            if (context is null) throw new ArgumentNullException(nameof(context));
            _context = context;
            _context.DbContext.Configuration.LazyLoadingEnabled = false;
        }

        public void Add(TEntity entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            _context.DbSet.Add(entity);
            _context.DbContext.SaveChanges();
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> results = _context.DbSet.AsNoTracking()
              .Where(predicate).ToList();
            return results;
        }

        public TEntity FindByKey(int id)
        {
            return _context.DbSet.AsNoTracking().SingleOrDefault(e => e.Id == id);
        }

        public void Update(TEntity entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            _context.DbSet.Attach(entity);
            _context.DbContext.Entry(entity).State = EntityState.Modified;
            _context.DbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            _context.DbSet.Attach(entity);
            _context.DbSet.Remove(entity);
            _context.DbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.DbSet.ToList();
        }

        public IEnumerable<TEntity> AllInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetAllIncluding(includeProperties).ToList();
        }

        public void Update(TEntity entity, Expression<Func<IUpdateConfiguration<TEntity>, object>> graph)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            if (graph is null) throw new ArgumentNullException(nameof(graph));
            _context.DbContext.UpdateGraph(entity, graph);
            _context.DbContext.SaveChanges();
        }

        public IEnumerable<TEntity> FindByInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            IEnumerable<TEntity> results = query.Where(predicate).ToList();
            return results;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        private IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var queryable = _context.DbSet.AsNoTracking();

            return includeProperties.Aggregate
              (queryable, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}