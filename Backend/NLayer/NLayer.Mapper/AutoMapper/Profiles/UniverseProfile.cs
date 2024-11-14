using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Universe;
using NLayer.Mapper.Responses.Universe;

namespace NLayer.Mapper.AutoMapper.Profiles;

public class UniverseProfile : Profile
{
    public UniverseProfile()
    {
        CreateMap<Universe, CreateUniverseRequest>().ReverseMap();
        CreateMap<Universe, CreatedUniverseResponse>().ReverseMap();
        CreateMap<Universe, UpdateUniverseRequest>().ReverseMap();
        CreateMap<Universe, UpdatedUniverseResponse>().ReverseMap();
        CreateMap<Universe, DeleteUniverseRequest>().ReverseMap();
        CreateMap<Universe, DeletedUniverseResponse>().ReverseMap();

        CreateMap<Universe, GetAllUniverseResponse>()
            .ForMember(dest => dest.ThemeSetting, opt => opt.MapFrom(src => src.ThemeSetting));
    }
}
