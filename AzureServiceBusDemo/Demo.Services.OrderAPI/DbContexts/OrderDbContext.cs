using Demo.Services.OrderAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Services.OrderAPI.DbContexts
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
        { }

        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<OrderHeader> OrderHeader { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
