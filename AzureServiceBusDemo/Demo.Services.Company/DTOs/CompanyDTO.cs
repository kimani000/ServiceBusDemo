using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Demo.Services.CompanyAPI.DTOs
{
    public class CompanyDTO
    {
        public Guid Id { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public int NumberOfEmployees { get; set; }

        public string WebsiteUrl { get; set; }

        public string PhoneNumber { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }
    }
}
