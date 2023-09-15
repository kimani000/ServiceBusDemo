using Demo.Services.ShoppingCartAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Demo.Services.ShoppingCartAPI.DTOs
{
    public class ShoppingCartDetailDTO
    {
        public Guid Id { get; set; }

        public Guid ShoppingCartId { get; set; }

        public Guid ProductId { get; set; }

        [JsonIgnore]
        public ProductDTO Product { get; set; }
        public int Count { get; set; }
    }
}
