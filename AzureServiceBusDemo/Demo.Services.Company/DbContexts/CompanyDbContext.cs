using Demo.Services.CompanyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Services.CompanyAPI.DbContexts
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        { }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>().HasData(new Company
            {
                Id = Guid.NewGuid(),
                CompanyName = "Nike",
                Description = "Just Do It!",
                NumberOfEmployees = 5000,
                WebsiteUrl = "www.nike.com",
                PhoneNumber = "777-448-8511",
                StreetAddress = "5684 Middleton Ave",
                City = "San Diego",
                State = "CA",
                ZipCode = "55255"
            });

            modelBuilder.Entity<Company>().HasData(new Company
            {
                Id = Guid.NewGuid(),
                CompanyName = "Adidas",
                Description = "The Brand With 3 Stripes!",
                NumberOfEmployees = 4000,
                WebsiteUrl = "www.adidas.com",
                PhoneNumber = "548-358-7711",
                StreetAddress = "6481 Southern Ave",
                City = "New York",
                State = "NY",
                ZipCode = "87246"
            });

            modelBuilder.Entity<Company>().HasData(new Company
            {
                Id = Guid.NewGuid(),
                CompanyName = "ASOS",
                Description = "We deliver the highest quality clothing for the lowest market price.",
                NumberOfEmployees = 1568,
                WebsiteUrl = "www.asos.com",
                PhoneNumber = "214-858-4478",
                StreetAddress = "618 Eastern St",
                City = "Phoenix",
                State = "AZ",
                ZipCode = "88452"
            });
        }
    }
}
