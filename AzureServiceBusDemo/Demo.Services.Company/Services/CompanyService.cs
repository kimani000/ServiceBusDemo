using Demo.Services.CompanyAPI.DbContexts;
using Demo.Services.CompanyAPI.Interfaces;
using Demo.Services.CompanyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Services.CompanyAPI.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly CompanyDbContext _context;

        public CompanyService(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> GetCompaniesAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(Guid companyId)
        {
            return await _context.Companies.FirstOrDefaultAsync(x => x.Id == companyId);
        }

        public async Task<Company> AddCompnayAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            _context.SaveChanges();

            return company;
        }

        public async Task<Company> DeleteCompanyAsync(Guid companyId)
        {
            var company = _context.Companies.FirstOrDefault(x => x.Id == companyId);

            if (company == null)
            {
                return null;
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return company;

        }

        public async Task<Company> UpdateCompanyAsyc(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();

            return company;
        }
    }
}
