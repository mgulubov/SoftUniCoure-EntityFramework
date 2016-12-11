namespace MassDefect.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using Interfaces;

    public class GenericDbRepository<TEntity> : IDbRepository<TEntity> where TEntity : class
    {
        private readonly MassDefectContext dbContext;
        private readonly DbSet<TEntity> dbSet;

        public GenericDbRepository(MassDefectContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.dbSet.AddRange(entities);
        }

        public void Remove(object id)
        {
            TEntity entity = this.dbSet.Find(id);

            this.Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            if (this.dbContext.Entry(entity).State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            this.dbSet.Remove(entity);
        }

        public void Remove(Expression<Func<TEntity, bool>> expression)
        {
            IEnumerable<TEntity> entities = this.dbSet.Where(expression);

            this.RemoveRange(entities);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            entities = entities.ToList();
            foreach (TEntity entity in entities)
            {
                if (this.dbContext.Entry(entity).State == EntityState.Deleted)
                {
                    this.dbSet.Attach(entity);
                }
            }

            this.dbSet.RemoveRange(entities);
        }

        public void Update(TEntity entityToUpdate)
        {
            this.dbSet.Attach(entityToUpdate);
            this.dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public TEntity Find(object id)
        {
            TEntity entity = this.dbSet.Find(id);

            return entity;
        }

        public TEntity First()
        {
            TEntity entity = this.dbSet.FirstOrDefault();

            return entity;
        }

        public TEntity First(Expression<Func<TEntity, bool>> expression)
        {
            TEntity entity = this.dbSet.Where(expression).FirstOrDefault();

            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            IEnumerable<TEntity> entities = this.dbSet.ToList();

            return entities;
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression)
        {
            IEnumerable<TEntity> entities = this.dbSet.Where(expression);

            return entities;
        }

        public int Count()
        {
            int count = this.dbSet.Count();

            return count;
        }

        public int Count(Expression<Func<TEntity, bool>> expression)
        {
            int count = this.dbSet.Where(expression).Count();

            return count;
        }
    }
}
