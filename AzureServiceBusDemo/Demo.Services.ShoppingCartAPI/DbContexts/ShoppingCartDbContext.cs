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
    }
}
