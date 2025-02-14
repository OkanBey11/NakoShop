using Microsoft.EntityFrameworkCore;
using NakoShop.Order.Domain.Entities;

namespace NakoShop.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MYLORDNAKO\\SQLEXPRESS;initial Catalog=MultiShopOrderDb;intergrated Security=true;TrustServerCertificate=True;");

        }
        public DbSet<Address> Adddresses {  get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
    }
}
