using Demo.Services.CompanyAPI.Interfaces;
using Demo.Services.CompanyAPI.Models;

namespace Demo.Services.CompanyAPI.Services
{
    public class CompanyService : ICompanyService
    {
        public Task<Company> AddCompnayAsync(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<Company> DeleteCompanyAsybc(Guid companyId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetCompanyByIdAsync(Guid companyId)
        {
            throw new NotImplementedException();
        }

        public Task<Company> UpdateCompanyAsyc(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
