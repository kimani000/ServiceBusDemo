using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Demo.Services.ShoppingCartAPI.Enums;

namespace Demo.Services.ShoppingCartAPI.Models
{
    [NotMapped]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 1000)]
        public double Price { get; set; }

        public string Description { get; set; }

        public StyleEnum Style { get; set; }

        public Guid CompanyId { get; set; }
    }
}
