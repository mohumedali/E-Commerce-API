using Microsoft.EntityFrameworkCore;
using MiniProject.Models;

namespace MiniProject.AppDbContext
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductOrderModel>().HasKey(po => new { po.ProductId, po.OrderId });
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ProductOrderModel> ProductOrders { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }



    }
}
