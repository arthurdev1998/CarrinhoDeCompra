using AutoMapper;
using Mongo.Services.CupomApi.Dtos;
using Mongo.Services.CupomApi.Entities;

namespace Mongo.Services.CupomApi.Mapping;

public class MappingConfig
{
    public static MapperConfiguration  RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<CupomDto, Cupom>().ReverseMap();
        });

        return mappingConfig;
    }   
}