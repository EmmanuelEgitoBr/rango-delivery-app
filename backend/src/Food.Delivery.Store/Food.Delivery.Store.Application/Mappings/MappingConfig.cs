using AutoMapper;
using Food.Delivery.Store.Application.Dtos;
using Food.Delivery.Store.Domain.Entities;

namespace Food.Delivery.Store.Application.Mappings
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMap()
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<Cliente, ClienteDto>().ReverseMap();
                
            }
            );
            return mapperConfiguration;
        }
    }
}
