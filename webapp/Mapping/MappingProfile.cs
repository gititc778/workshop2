using AutoMapper;
using TireShopWeb.Models;

namespace TireShopWeb.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Tire, Tire>();
    }
}
