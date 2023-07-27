using AutoMapper;
using Demo.Services.CompanyAPI.DTOs;
using Demo.Services.CompanyAPI.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace Demo.Services.CompanyAPI.Mappers
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();

            /*
             *  Below code is not needed, but serves as a good exampl on manual mapping
             */

            //CreateMap<Product, ProductDTO>()
            //    .ForMember(dest => dest.CompanyId, option => option.MapFrom(source => source.CompanyId));
            //CreateMap<ProductDTO, Product>()
            //    .ForMember(dest => dest.CompanyId, option => option.MapFrom(source => source.CompanyId));
        }
    }
}
