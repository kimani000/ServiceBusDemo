using Demo.Services.ShoppingCartAPI.Models;

namespace Demo.Services.ShoppingCartAPI.DTOs
{
    public class ShoppingCartDTO
    {
        public Guid Id { get; set; }

        public IEnumerable<ShoppingCartDetailDTO> ShoppingCartDetail { get; set; }

        public Guid UserId { get; set; }
    }
}
