using DAL.Config;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure.Annotations;

namespace DAL
{
    public class DatabaseContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Feature> features { get; set; }
        public DbSet<ViewersStatistics> viewersStatistics { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<ProductOrder> productOrders { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Article> articles { get; set; }
        public DbSet<OrderPaid> orderPaids { get; set; }
        public DbSet<ProductOrderPaid> productOrderPaid { get; set; }
        public DbSet<Archive> archive { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> option) : base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // this is for error ::: IdentityUserLogin<string> ::::
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(p => new { p.LoginProvider, p.ProviderKey });
            //modelBuilder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId });
            //modelBuilder.Entity<IdentityUserToken<string>>().HasKey(p => new { p.UserId, p.LoginProvider, p.Name });
            





            modelBuilder.ApplyConfiguration(new AppRoleConfig());
            modelBuilder.ApplyConfiguration(new AppUserConfig());
            modelBuilder.ApplyConfiguration(new UserRoleConfig());
            modelBuilder.ApplyConfiguration(new ArticleConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new ProductOrderConfig());
            modelBuilder.ApplyConfiguration(new ProductOrderPaidConfig());
            modelBuilder.ApplyConfiguration(new FeatureConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new OrderPaidConfig());
            modelBuilder.ApplyConfiguration(new ArchiveConfig());
            modelBuilder.ApplyConfiguration(new CommentConfig());

        }
    }
}
