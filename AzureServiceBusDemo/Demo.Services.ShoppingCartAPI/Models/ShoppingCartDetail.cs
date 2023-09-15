using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Services.ShoppingCartAPI.Models
{
    [Table(nameof(ShoppingCartDetail))]
    public class ShoppingCartDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Guid ShoppingCartId { get; set; }

        [ForeignKey(nameof(ShoppingCartId))]
        public ShoppingCart ShoppingCart { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
