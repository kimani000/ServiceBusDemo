using Demo.Services.CompanyAPI.DbContexts;
using Demo.Services.CompanyAPI.DTOs;
using Demo.Services.CompanyAPI.Interfaces;
using Demo.Services.CompanyAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Demo.Services.CompanyAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly CompanyDbContext _context;

        public ProductService(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid productId, bool withTracking = true)
        {
            if (withTracking)
            {
                return await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);

            }

            return await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == productId);
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            _context.SaveChanges();

            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }
        public async Task<Product> DeleteProductAsync(Guid productId)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productId);

            if (product == null)
            {
                return null;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> PatchProductAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return product;
        }
    }
}
