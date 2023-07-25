using Demo.Services.CompanyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Services.CompanyAPI.DbContexts
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        { }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Product>()
            //    .HasOne(p => p.Company)
            //    .WithMany(c => c.Products)
            //    .HasForeignKey(p => p.CompanyId);
            
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = Guid.NewGuid(),
                Name = "oversized T-shirt in beige ribbed velour",
                Price = 32.00,
                Description = "Model's height: 188cm / 6' 2'. Model is wearing: Medium",
                Style = Enums.StyleEnum.Shirts,
                CompanyId = Guid.Parse("5108F4F8-2089-44D9-8AD1-06C3614F3CD5")
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = Guid.NewGuid(),
                Name = "versized t-shirt in dark khaki with back fruit print",
                Price = 26.10,
                Description = "Machine wash according to instructions on care labels",
                Style = Enums.StyleEnum.Shirts,
                CompanyId = Guid.Parse("BB70A575-4973-4E63-BED4-7CAAE254364D")
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = Guid.NewGuid(),
                Name = "Nicce renee shorts in beige",
                Price = 62.00,
                Description = "Plain-woven fabric. Main: 100% Polyester.",
                Style = Enums.StyleEnum.Shorts,
                CompanyId = Guid.Parse("A6B28790-528F-416D-9061-DEE0FB935E22")
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = Guid.NewGuid(),
                Name = "satin slim shorts in black",
                Price = 110.00,
                Description = "Satin-style fabric: glossy, drapey and silky-smooth. Main: 97% Cotton, 3% Elastane.",
                Style = Enums.StyleEnum.Shorts,
                CompanyId = Guid.Parse("5108F4F8-2089-44D9-8AD1-06C3614F3CD5")
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = Guid.NewGuid(),
                Name = "oversized denim jacket in mid wash",
                Price = 195.00,
                Description = "Non-stretch denim: mid-blue wash. Main: 100% Cotton.",
                Style = Enums.StyleEnum.Jackets,
                CompanyId = Guid.Parse("BB70A575-4973-4E63-BED4-7CAAE254364D")
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = Guid.NewGuid(),
                Name = "COLLUSION cord jacket in chocolate brown",
                Price = 86.90,
                Description = "Corduroy: ribbed, velvet-feel texture. Lining: 100% Polyester, Rib: 99% Polyester, 1% Elastane, Shell: 91% Polyester, 9% Nylon, Wadding: 100% Polyester.",
                Style = Enums.StyleEnum.Jackets,
                CompanyId = Guid.Parse("A6B28790-528F-416D-9061-DEE0FB935E22")
            });
        }
    }
}
