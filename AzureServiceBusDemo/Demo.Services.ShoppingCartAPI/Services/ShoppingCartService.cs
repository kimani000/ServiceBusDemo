using Demo.Services.ShoppingCartAPI.DbContexts;
using Demo.Services.ShoppingCartAPI.Interfaces;
using Demo.Services.ShoppingCartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Services.ShoppingCartAPI.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ShoppingCartDbContext _context;

        public ShoppingCartService(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public async Task<ShoppingCart> GetShoppingCartById(Guid cartId)
        {
            return await _context.ShoppingCarts
                .Include(x => x.ShoppingCartDetail)
                .FirstOrDefaultAsync(x => x.Id == cartId);
        }
        public async Task<ShoppingCartDetail> AddToShoppingCart(ShoppingCartDetail cartDetail)
        {
            var cartExists = _context.ShoppingCarts.Any(x => x.Id == cartDetail.ShoppingCartId);

            if (!cartExists) 
            {
                return null;
            }

            await _context.ShoppingCartDetails.AddAsync(cartDetail);
            _context.SaveChanges();

            return cartDetail;
        }

        public async Task<ShoppingCartDetail> GetShoppingCartDetailById(Guid id)
        {
            return await _context.ShoppingCartDetails.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ShoppingCartDetail> RemoveFromShoppingCart(Guid cartDetailId)
        {
            var cartDetail = await _context.ShoppingCartDetails.FirstOrDefaultAsync(x => x.Id == cartDetailId);

            if (cartDetail == null)
            {
                return null;
            }

            _context.ShoppingCartDetails.Remove(cartDetail);
            await _context.SaveChangesAsync();

            return cartDetail;
        }

        public async Task<ShoppingCartDetail> PatchShoppingCartDetail(ShoppingCartDetail cartDetail)
        {
            var cartExists = _context.ShoppingCarts.Any(x => x.Id == cartDetail.ShoppingCartId);

            if (!cartExists) 
            { 
                return null; 
            }

            _context.Entry(cartDetail).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return cartDetail;
        }

        public async Task<bool> ClearShoppingCart(Guid cartId)
        {
            var shoppingCartExists = _context.ShoppingCarts.Any(x => x.Id == cartId);

            if(!shoppingCartExists)
            {
                return false;
            }
            /*
             * NOTE:
             *      ExecuteDelete performs a bulk delete on rows with matching argument.
             *      In this case, every shopping cart detail that belongs to this shopping cart will get deleted sequentially.
             *      
             *      This operation is directly performed on the database, so there is no need to save changes.
             *      
             *      EF change tracker does not keep track of this transaction. I think this can be solved by getting the cart again,
             *      and returning that to ensure that the client gets an "update".
             */
            await _context.ShoppingCartDetails
                .Where(x => x.ShoppingCartId == cartId)
                .ExecuteDeleteAsync();

            return true;
        }

        public async Task<ShoppingCart> CreateShoppingCart(Guid userId)
        {
            var userHasCart = _context.ShoppingCarts.Any(x => x.UserId == userId);

            if (userHasCart)
            {
                return null;
            }

            ShoppingCart shoppingCart = new()
            {
                UserId = userId
            };

           await _context.ShoppingCarts.AddAsync(shoppingCart);
            _context.SaveChanges();

            return shoppingCart;
        }

        public async Task<bool> DeleteCartAsync(Guid userId, Guid cartId)
        {
            var cart = await _context.ShoppingCarts.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == cartId);

            if (cart == null) 
            {
                return false;   
            }

            _context.ShoppingCarts.Remove(cart);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
