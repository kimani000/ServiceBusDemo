using Demo.Services.AccountAPI.DbContexts;
using Demo.Services.AccountAPI.Interfaces;
using Demo.Services.AccountAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Services.AccountAPI.Services
{
    public class AccountService : IAccountService
    {
        private readonly AccountDbContext _context;

        public AccountService(AccountDbContext context)
        {
            _context = context;
        }

        public async Task<Account> GetAccountByIdAsync(Guid userId, bool withTracking = true)
        {
            if (withTracking)
            {
                return await _context.Accounts.FirstOrDefaultAsync(x => x.Id == userId);
            }

            return await _context.Accounts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<bool> DeleteAccountAsync(Guid userId)
        {
            var account = _context.Accounts.FirstOrDefault(x => x.Id == userId);

            if (account == null)
            {
                return false;
            }

            _context.Remove(account);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<Account> PatchAccountAsync(Account account)
        {
            var accountExists = _context.Accounts.Any(x => x.Id == account.Id);

            if (!accountExists)
            {
                return null;
            }

            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return account;
        }
    }
}
