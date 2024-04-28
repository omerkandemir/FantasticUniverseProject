using AutoMapper;
using NLayer.Dto.Requests.Universe;
using NLayer.Dto.Responses.Universe;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.AutoMapper.Profiles;

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
        CreateMap<Universe, GetAllUniverseResponse>().ReverseMap();
    }
}
