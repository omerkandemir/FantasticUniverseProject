using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Universe;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Adventure;
using NLayer.Mapper.Responses.Concrete.Universe;

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
        CreateMap<Universe, GetUniverseResponse>()
            .ForMember(dest => dest.ThemeSetting, opt => opt.MapFrom(src => src.ThemeSetting)).ReverseMap();
        CreateMap<Universe, GetAllUniverseResponse>().ReverseMap();

        CreateMap<Universe, IGetUniverseResponse>().As<GetUniverseResponse>();

        CreateMap<ICollection<Universe>, GetAllUniverseResponse>()
            .ForMember(dest => dest.Responses, opt => opt.MapFrom(src => src));
    }
}
