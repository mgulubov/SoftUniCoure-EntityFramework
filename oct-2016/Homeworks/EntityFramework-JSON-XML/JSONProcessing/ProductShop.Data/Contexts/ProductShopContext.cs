namespace ProductShop.Data.Contexts
{
    using System.Data.Entity;

    using Models;

    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
            : base("name=ProductShopContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany<User>(u => u.Friends)
                .WithMany(u => u.Users)
                .Map(uf =>
                        {
                            uf.MapLeftKey("UserId");
                            uf.MapRightKey("FriendId");
                            uf.ToTable("UserFriends");
                        });

            modelBuilder.Entity<Product>()
                .HasMany<Category>(p => p.Categories)
                .WithMany(c => c.Products)
                .Map(cp =>
                        {
                            cp.MapLeftKey("CategoryId");
                            cp.MapRightKey("ProductId");
                            cp.ToTable("CategoryProducts");
                        });
        }
    }
}