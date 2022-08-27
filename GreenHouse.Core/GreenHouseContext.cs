using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GreenHouse.Core
{
    public partial class GreenHouseContext : DbContext
    {
        public GreenHouseContext()
            : base("name=GreenHouseContext")
        {
        }

        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductBrand> ProductBrands { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductProducer> ProductProducers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserFavoriteProductList> UserFavoriteProductLists { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>()
                .HasMany(e => e.ProductCategory1)
                .WithOptional(e => e.ProductCategory2)
                .HasForeignKey(e => e.TopCategory);

            modelBuilder.Entity<ProductProducer>()
                .Property(e => e.ProducerName)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Products1)
                .WithOptional(e => e.User1)
                .HasForeignKey(e => e.UserAdminId);
        }
    }
}
