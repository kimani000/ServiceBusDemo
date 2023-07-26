using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Services.CompanyAPI.Models
{
    [Table(nameof(Company))]
    public class Company
    {
        public Company()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string CompanyName { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [Range(0, 10000)]
        public int NumberOfEmployees { get; set; }
        
        [MaxLength(50)]
        public string WebsiteUrl { get; set; }
        
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [MaxLength(50)]
        public string StreetAddress { get; set; }

        [MaxLength(15)]
        public string City { get; set; }

        [MaxLength(10)]
        public string State { get; set; }

        [MaxLength(10)]
        public string ZipCode { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
