using AutoMapper;
using NLayer.Dto.Requests.Planet;
using NLayer.Dto.Responses.Planet;
using NLayer.Entities.Concretes;

namespace WebApi.Mapping;

public class PlanetMapping : Profile
{
    public PlanetMapping()
    {
        CreateMap<Planet, CreatePlanetRequest>().ReverseMap();
        CreateMap<CreatedPlanetResponse, Planet>().ReverseMap();
        CreateMap<Planet, UpdatePlanetRequest>().ReverseMap();
        CreateMap<UpdatedPlanetResponse, Planet>().ReverseMap();
        CreateMap<Planet, DeletePlanetRequest>().ReverseMap();
        CreateMap<DeletedPlanetResponse, Planet>().ReverseMap();
        CreateMap<Planet, GetAllPlanetResponse>().ReverseMap();
    }
}
