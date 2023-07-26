using AutoMapper;
using Demo.Services.CompanyAPI.DTOs;
using Demo.Services.CompanyAPI.Models;

namespace Demo.Services.CompanyAPI.Mappers
{
    public class CompanyMapper : Profile
    {
        public CompanyMapper()
        {
            CreateMap<Company, CompanyDTO>().ReverseMap();
        }
    }
}
