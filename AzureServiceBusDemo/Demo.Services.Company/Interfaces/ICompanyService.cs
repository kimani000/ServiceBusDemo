using Demo.Services.CompanyAPI.Models;

namespace Demo.Services.CompanyAPI.Interfaces
{
    public interface ICompanyService
    {
        Task<List<Company>> GetCompaniesAsync();
        Task<Company> GetCompanyByIdAsync(Guid companyId);
        Task<Company> AddCompnayAsync(Company company);
        Task<Company> UpdateCompanyAsyc(Company company);
        Task<Company> DeleteCompanyAsync(Guid companyId);
    }
}
