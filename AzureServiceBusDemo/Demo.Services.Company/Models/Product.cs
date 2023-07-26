using Demo.Services.CompanyAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Services.CompanyAPI.Models
{
    [Table(nameof(Product))]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(1, 1000)]
        public double Price { get; set; }

        public string Description { get; set; }
        public StyleEnum Style { get; set; }

        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}

