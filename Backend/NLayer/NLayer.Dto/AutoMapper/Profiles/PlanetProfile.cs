using AutoMapper;
using NLayer.Dto.Requests.Planet;
using NLayer.Dto.Responses.Planet;
using NLayer.Entities.Concretes;

namespace NLayer.Dto.AutoMapper.Profiles;

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
