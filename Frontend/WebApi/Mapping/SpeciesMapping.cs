using AutoMapper;
using NLayer.Dto.Requests.Species;
using NLayer.Dto.Responses.Species;
using NLayer.Entities.Concretes;

namespace WebApi.Mapping;

public class SpeciesMapping : Profile
{
    public SpeciesMapping()
    {
        CreateMap<Species, CreateSpeciesRequest>().ReverseMap();
        CreateMap<CreatedSpeciesResponse, Species>().ReverseMap();
        CreateMap<Species, UpdateSpeciesRequest>().ReverseMap();
        CreateMap<UpdatedSpeciesResponse, Species>().ReverseMap();
        CreateMap<Species, DeleteSpeciesRequest>().ReverseMap();
        CreateMap<DeletedSpeciesResponse, Species>().ReverseMap();
        CreateMap<Species, GetAllSpeciesResponse>().ReverseMap();
    }
}
