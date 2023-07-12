using AutoMapper;
using Demo.Services.CompanyAPI.DTOs;
using Demo.Services.CompanyAPI.Models;

namespace Demo.Services.CompanyAPI.Configurations
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Company, CompanyDTO>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
