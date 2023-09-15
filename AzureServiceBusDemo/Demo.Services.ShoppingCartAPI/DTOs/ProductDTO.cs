using Demo.Services.ShoppingCartAPI.Enums;

namespace Demo.Services.ShoppingCartAPI.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public StyleEnum Style { get; set; }

        public Guid CompanyId { get; set; }
    }
}
