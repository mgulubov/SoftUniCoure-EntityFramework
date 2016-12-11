namespace ProductShop.Data.UnitOfWork
{
    using System;

    using Contexts;
    using Interfaces;
    using Repositories;
    using Models;

    public class GenericUnitOfWork : IUnitOfWork
    {
        private readonly ProductShopContext dbContext;

        private IRepository<User> usersRepository;
        private IRepository<Product> productsRepository;
        private IRepository<Category> categoriesRepository;

        private bool isDisposed = false;

        public GenericUnitOfWork()
        {
            this.dbContext = new ProductShopContext();
        }

        public IRepository<User> UsersRepository
            => this.usersRepository ?? (this.usersRepository = new GenericRepository<User>(this.dbContext));

        public IRepository<Product> ProductsRepository
            => this.productsRepository ?? (this.productsRepository = new GenericRepository<Product>(this.dbContext));

        public IRepository<Category> CategoriesRepository
            =>
                this.categoriesRepository ??
                (this.categoriesRepository = new GenericRepository<Category>(this.dbContext));

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }

        public void Dispose(bool isDisposing)
        {
            if (!this.isDisposed)
            {
                if (isDisposing)
                {
                    this.dbContext.Dispose();
                }
            }

            this.isDisposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
