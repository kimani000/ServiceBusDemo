using AutoMapper;
using Demo.Services.CompanyAPI.DTOs;
using Demo.Services.CompanyAPI.Models;

namespace Demo.Services.CompanyAPI.Mappers
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            //config.CreateMap<Product, ProductDTO>()
            //    .ForMember(dest => dest.Company, member => member.MapFrom(product => product.Company));
            //config.CreateMap<ProductDTO, Product>()
            //    .ForMember(dest => dest.CompanyId, member => member.MapFrom(dto => dto.Company.Id));
        }
    }
}
