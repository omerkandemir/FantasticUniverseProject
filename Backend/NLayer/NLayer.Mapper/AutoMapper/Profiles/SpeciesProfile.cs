using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Species;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Adventure;
using NLayer.Mapper.Responses.Concrete.Species;

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
        CreateMap<Species, GetSpeciesResponse>().ReverseMap();
        CreateMap<Species, GetAllSpeciesResponse>().ReverseMap();

        CreateMap<Species, IGetSpeciesResponse>().As<GetSpeciesResponse>();

        CreateMap<ICollection<Species>, GetAllSpeciesResponse>()
            .ForMember(dest => dest.Responses, opt => opt.MapFrom(src => src));
    }
}
