namespace ProductShop.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using Contexts;
    using Interfaces;

    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class 
    {
        private readonly ProductShopContext dbContext;
        private readonly DbSet<TEntity> dbSet;

        public GenericRepository(ProductShopContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.Set<TEntity>();
        }

        public virtual TEntity GetByPrimaryKey(object primaryKey)
        {
            TEntity entity = this.dbSet.Find(primaryKey);
            return entity;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            ICollection<TEntity> entitySet = this.dbSet.ToList();
            return entitySet;
        }

        public virtual IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> getFilter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string[] includeProperties = null)
        {
            IQueryable<TEntity> filteredSet = this.dbSet.Where(getFilter);

            this.IncludePropertiesIn(filteredSet, includeProperties);
            this.Order(filteredSet, orderBy);

            return filteredSet.ToList();
        }

        public virtual void Insert(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = this.dbSet.Find(id);
            this.Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (this.dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                this.dbSet.Attach(entityToDelete);
            }

            this.dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            this.dbSet.Attach(entityToUpdate);
            this.dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        private void IncludePropertiesIn(IQueryable<TEntity> entitySet, string[] propertiesToInclude)
        {
            if (propertiesToInclude != null && propertiesToInclude.Length > 0)
            {
                foreach (string property in propertiesToInclude)
                {
                    entitySet = entitySet.Include(property);
                }
            }
        }

        private void Order(
            IQueryable<TEntity> entitySet,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderByFunc)
        {
            if (orderByFunc != null)
            {
                entitySet = orderByFunc(entitySet);
            }
        }
    }
}
