using Demo.Services.AccountAPI.Models;

namespace Demo.Services.AccountAPI.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// Get an account by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<Account> GetAccountByIdAsync(Guid userId, bool withTracking = true);

        /// <summary>
        /// Delete an account
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> DeleteAccountAsync(Guid userId);

        /// <summary>
        /// Patch an account
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        Task<Account> PatchAccountAsync(Account account);
    }
}
