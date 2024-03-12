using AutoMapper;
using NLayer.Dto.Requests.Universe;
using NLayer.Dto.Responses.Universe;
using NLayer.Entities.Concretes;

namespace WebApi.Mapping;

public class UniverseMapping : Profile
{
    public UniverseMapping()
    {
        CreateMap<Universe, CreateUniverseRequest>().ReverseMap();
        CreateMap<CreatedUniverseResponse, Universe>().ReverseMap();
        CreateMap<Universe, UpdateUniverseRequest>().ReverseMap();
        CreateMap<UpdatedUniverseResponse, Universe>().ReverseMap();
        CreateMap<Universe, DeleteUniverseRequest>().ReverseMap();
        CreateMap<DeletedUniverseResponse, Universe>().ReverseMap();
        CreateMap<Universe, GetAllUniverseResponse>().ReverseMap();
    }
}
