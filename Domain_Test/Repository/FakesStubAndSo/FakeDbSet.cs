using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Domain_Test.Repository.FakesStubAndSo
{
    public class FakeDbset<TEntity> : IDbSet<TEntity> where TEntity : class
    {
        public FakeDbset(ObservableCollection<TEntity> testEntities)
        {
            Local = testEntities;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return Local.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Expression Expression => Local.AsQueryable().Expression;
        public Type ElementType => Local.AsQueryable().ElementType;
        public IQueryProvider Provider => Local.AsQueryable().Provider;

        public TEntity Add(TEntity entity)
        {
            Local.Add(entity);
            return entity;
        }

        public TEntity Remove(TEntity entity)
        {
            Local.Remove(entity);
            return entity;
        }

        public TEntity Attach(TEntity entity)
        {
            //Local.Add(entity);
            return entity;
        }

        public TEntity Create()
        {
            throw new NotImplementedException();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, TEntity
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<TEntity> Local { get; }

        public TEntity Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }
    }
}