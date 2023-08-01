using Demo.Services.CompanyAPI.DTOs;
using Demo.Services.CompanyAPI.Models;
using Demo.Services.CompanyAPI.Services;
using Microsoft.AspNetCore.JsonPatch;

namespace Demo.Services.CompanyAPI.Interfaces
{
    /// <summary>
    /// This interface is implemented by <see cref="ProductService"/> and is used to access Company table in db.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets all products
        /// </summary>
        /// <returns></returns>
        Task<List<Product>> GetProductsAsync();

        /// <summary>
        /// Gets a single product by Id with or without tracking
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<Product> GetProductByIdAsync(Guid productId, bool withTracking = true);

        /// <summary>
        ///  Adds a new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<Product> AddProductAsync(Product product);

        /// <summary>
        /// Updates a product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<Product> UpdateProductAsync(Product product);

        /// <summary>
        /// Deletes a product by Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<Product> DeleteProductAsync(Guid productId);

        /// <summary>
        /// Tracks the patched product then saves the change
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<Product> PatchProductAsync(Product prouct);
    }
}
