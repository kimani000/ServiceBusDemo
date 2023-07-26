using Demo.Services.CompanyAPI.Models;
using Demo.Services.CompanyAPI.Services;

namespace Demo.Services.CompanyAPI.Interfaces
{
    /// <summary>
    /// This interface is implemented by <see cref="CompanyService"/> and is used to access Company table in db.
    /// </summary>
    public interface ICompanyService
    {
        /// <summary>
        /// Gets all companies
        /// </summary>
        /// <returns></returns>
        Task<List<Company>> GetCompaniesAsync();

        /// <summary>
        /// Gets a single company by Id
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<Company> GetCompanyByIdAsync(Guid companyId);

        /// <summary>
        ///  Adds a new company
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        Task<Company> AddCompnayAsync(Company company);

        /// <summary>
        /// Updates a company
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        Task<Company> UpdateCompanyAsyc(Company company);

        /// <summary>
        /// Deletes a company by Id
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        Task<Company> DeleteCompanyAsync(Guid companyId);
    }
}
