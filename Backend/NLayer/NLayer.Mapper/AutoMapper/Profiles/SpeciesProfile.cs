using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Species;
using NLayer.Mapper.Responses.Species;

namespace NLayer.Mapper.AutoMapper.Profiles;

public class SpeciesProfile : Profile
{
    public SpeciesProfile()
    {
        CreateMap<Species, CreateSpeciesRequest>().ReverseMap();
        CreateMap<Species, CreatedSpeciesResponse>().ReverseMap();
        CreateMap<Species, UpdateSpeciesRequest>().ReverseMap();
        CreateMap<Species, UpdatedSpeciesResponse>().ReverseMap();
        CreateMap<Species, DeleteSpeciesRequest>().ReverseMap();
        CreateMap<Species, DeletedSpeciesResponse>().ReverseMap();
        CreateMap<Species, GetAllSpeciesResponse>().ReverseMap();
    }
}
