namespace MassDefect.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IDbRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Remove(object id);

        void Remove(TEntity entity);

        void Remove(Expression<Func<TEntity, bool>> expression);

        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entityToUpdate);

        TEntity Find(object id);

        TEntity First();

        TEntity First(Expression<Func<TEntity, bool>> expression);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression);

        int Count();

        int Count(Expression<Func<TEntity, bool>> expression);
    }
}
