using AutoMapper;
using Demo.Services.ShoppingCartAPI.DTOs;
using Demo.Services.ShoppingCartAPI.Models;

namespace Demo.Services.ShoppingCartAPI.Mappers
{
    public class ShoppingCartMapper : Profile
    {
        public ShoppingCartMapper() 
        {
            CreateMap<ShoppingCart, ShoppingCartDTO>().ReverseMap();
            CreateMap<ShoppingCartDetail, ShoppingCartDetailDTO>();
            CreateMap<ShoppingCartDetailDTO, ShoppingCartDetail>()
                .ForMember(dest => dest.Product, options => options.Ignore()) // This is how we can ignore a prop when mapping
                .ForMember(dest => dest.ProductId, options => options.MapFrom(source => source.ProductId));
        }
    }
}
