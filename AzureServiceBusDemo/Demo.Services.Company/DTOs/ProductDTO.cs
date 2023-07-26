using Demo.Services.CompanyAPI.Enums;
using Demo.Services.CompanyAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Demo.Services.CompanyAPI.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }
        public StyleEnum Style { get; set; }
        public Company Company { get; set; }
    }
}
