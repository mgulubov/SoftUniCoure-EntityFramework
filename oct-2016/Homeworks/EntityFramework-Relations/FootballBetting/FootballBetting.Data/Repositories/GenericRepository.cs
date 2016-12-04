namespace FootballBetting.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using Contexts;

    public class GenericRepository<TEntity> where TEntity : class
    {
        public GenericRepository(FootballBettingContext context)
        {
            this.Context = context;
            this.DbSet = this.Context.Set<TEntity>();
        }

        internal FootballBettingContext Context { get; set; }

        internal DbSet<TEntity> DbSet { get; set; }

        public virtual IEnumerable<TEntity> GetFiltered(
            Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
            string includeProperties = "")
        {
            IQueryable<TEntity> filteredSet = this.DbSet;

            if (filter != null)
            {
                filteredSet = filteredSet.Where(filter);
            }

            foreach (string property in includeProperties.Split(
                new char[] { ',' }, 
                StringSplitOptions.RemoveEmptyEntries))
            {
                filteredSet = filteredSet.Include(property);
            }

            if (orderBy != null)
            {
                return orderBy(filteredSet).ToList();
            }
            else
            {
                return filteredSet.ToList();
            }
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.DbSet;
        }

        public virtual TEntity GetWithPrimaryKey(object primaryKey)
        {
            return this.DbSet.Find(primaryKey);
        }

        public virtual void Insert(TEntity entity)
        {
            this.DbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = this.DbSet.Find(id);
            this.Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (this.Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                this.DbSet.Attach(entityToDelete);
            }

            this.DbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            this.DbSet.Attach(entityToUpdate);
            this.Context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
