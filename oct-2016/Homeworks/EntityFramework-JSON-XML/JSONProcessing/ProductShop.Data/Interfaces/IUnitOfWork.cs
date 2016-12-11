using System;
using ProductShop.Models;

namespace ProductShop.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UsersRepository { get; }

        IRepository<Product> ProductsRepository { get; }

        IRepository<Category> CategoriesRepository { get; }

        void Commit();
    }
}
