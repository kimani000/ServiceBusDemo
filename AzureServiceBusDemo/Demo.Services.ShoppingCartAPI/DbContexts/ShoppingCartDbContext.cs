using Demo.Services.ShoppingCartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Services.ShoppingCartAPI.DbContexts
{
    public class ShoppingCartDbContext: DbContext
    {
        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options) : base(options)
        { }

        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<ShoppingCartDetail> ShoppingCartDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCartDetail>().HasData(new ShoppingCartDetail() 
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = Guid.Parse("55BD8681-B566-4286-80A5-7763FA964C88"),
                ProductId = Guid.Parse("63846C08-4514-4A7B-1213-08DB8E4F008F"),
                Count = 3,
            });

            modelBuilder.Entity<ShoppingCartDetail>().HasData(new ShoppingCartDetail()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = Guid.Parse("55BD8681-B566-4286-80A5-7763FA964C88"),
                ProductId = Guid.Parse("9A637913-87C9-4741-B5F3-1B4FF7A98AD9"),
                Count = 4
            });

            modelBuilder.Entity<ShoppingCartDetail>().HasData(new ShoppingCartDetail()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = Guid.Parse("890A05E1-E229-4126-989D-B76BD9287DBE"),
                ProductId = Guid.Parse("9135CB05-9652-4717-A4A6-81BF042FB86C"),
                Count = 2
            });

            modelBuilder.Entity<ShoppingCartDetail>().HasData(new ShoppingCartDetail()
            {
                Id = Guid.NewGuid(),
                ShoppingCartId = Guid.Parse("890A05E1-E229-4126-989D-B76BD9287DBE"),
                ProductId = Guid.Parse("61777B2C-964D-4AD7-974C-DC75037E4B89"),
                Count = 1
            });
        }
    }
}
