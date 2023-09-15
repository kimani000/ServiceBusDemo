using Demo.Services.ShoppingCartAPI.Models;

namespace Demo.Services.ShoppingCartAPI.Interfaces
{
    public interface IShoppingCartService
    {
        /// <summary>
        /// Gets a shopping cart
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        Task<ShoppingCart> GetShoppingCartById(Guid cartId);

        /// <summary>
        /// Adds a new cart detail to a shopping cart
        /// </summary>
        /// <param name="cartDetail"></param>
        /// <returns></returns>
        Task<ShoppingCartDetail> AddToShoppingCart(ShoppingCartDetail cartDetail);

        /// <summary>
        /// Gets a shopping cart detail
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ShoppingCartDetail> GetShoppingCartDetailById(Guid id);

        /// <summary>
        /// Removes a cart detail from a shopping cart
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="cartDetailId"></param>
        /// <returns></returns>
        Task<ShoppingCartDetail> RemoveFromShoppingCart(Guid cartDetailId);

        /// <summary>
        /// Patch a cart detail in a shopping cart
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="cartDetail"></param>
        /// <returns></returns>
        Task<ShoppingCartDetail> PatchShoppingCartDetail(ShoppingCartDetail cartDetail);

        /// <summary>
        /// Clears a shopping cart
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        Task<bool> ClearShoppingCart(Guid cartId);
        
        /// <summary>
        /// Creates a new shopping cart
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<ShoppingCart> CreateShoppingCart(Guid userId);

        /// <summary>
        /// Deletes a user's shopping cart
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cartId"></param>
        /// <returns></returns>
        Task<bool> DeleteCartAsync(Guid userId, Guid cartId);
    }
}
