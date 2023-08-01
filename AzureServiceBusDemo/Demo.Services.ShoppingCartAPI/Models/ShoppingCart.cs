using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Services.ShoppingCartAPI.Models
{
    [Table(nameof(ShoppingCart))]
    public class ShoppingCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public virtual ICollection<ShoppingCartDetail> ShoppingCartDetail { get; set; }
    }
}
