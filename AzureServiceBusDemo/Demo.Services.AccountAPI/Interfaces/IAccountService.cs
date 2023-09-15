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
        Task<Account> GetAccountById(Guid userId);

        /// <summary>
        /// Delete an account
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> DeleteAccount(Guid userId);

        /// <summary>
        /// Patch an account
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        Task<Account> PatchAccount(Account account);
    }
}
