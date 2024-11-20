using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Planet;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Adventure;
using NLayer.Mapper.Responses.Concrete.Planet;

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
        CreateMap<Planet, GetPlanetResponse>().ReverseMap();
        CreateMap<Planet, GetAllPlanetResponse>().ReverseMap();

        CreateMap<Planet, IGetPlanetResponse>().As<GetPlanetResponse>();

        CreateMap<ICollection<Planet>, GetAllPlanetResponse>()
            .ForMember(dest => dest.Responses, opt => opt.MapFrom(src => src));
    }
}
