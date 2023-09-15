using Demo.Services.AccountAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Services.AccountAPI.DbContexts
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> context) : base(context)
        { }

        public virtual DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(new Account()
            {
                Id = Guid.NewGuid(),
                FirstName = "Kimani",
                LastName = "Avery",
                Email = "kimavery@gmail.com",
                FullAddress = "1212 N Vegas St, CityScape NV 54898", 
            });

            modelBuilder.Entity<Account>().HasData(new Account()
            {
                Id = Guid.NewGuid(),
                FirstName = "Tom",
                LastName = "Ford",
                Email = "tomf@outlook.com",
                FullAddress = "4859 Uptown Blvd, Downtowm TX 98922",
            });
        }
    }
}
