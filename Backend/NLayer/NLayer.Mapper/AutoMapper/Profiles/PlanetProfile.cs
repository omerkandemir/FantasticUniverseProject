using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Planet;
using NLayer.Mapper.Responses.Planet;

namespace NLayer.Mapper.AutoMapper.Profiles;

public class PlanetProfile : Profile
{
    public PlanetProfile()
    {
        CreateMap<Planet, CreatePlanetRequest>().ReverseMap();
        CreateMap<Planet, CreatedPlanetResponse>().ReverseMap();
        CreateMap<Planet, UpdatePlanetRequest>().ReverseMap();
        CreateMap<Planet, UpdatedPlanetResponse>().ReverseMap();
        CreateMap<Planet, DeletePlanetRequest>().ReverseMap();
        CreateMap<Planet, DeletedPlanetResponse>().ReverseMap();
        CreateMap<Planet, GetAllPlanetResponse>().ReverseMap();
    }
}
