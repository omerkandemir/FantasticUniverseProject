using AutoMapper;
using NLayer.Dto.Requests.Species;
using NLayer.Dto.Responses.Species;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.AutoMapper.Profiles;

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
