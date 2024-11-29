using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Galaxy;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Galaxy;

namespace NLayer.Mapper.AutoMapper.Profiles;

public class GalaxyProfile : Profile
{
    public GalaxyProfile()
    {
        CreateMap<Galaxy, CreateGalaxyRequest>().ReverseMap();
        CreateMap<Galaxy, CreatedGalaxyResponse>().ReverseMap();
        CreateMap<Galaxy, UpdateGalaxyRequest>().ReverseMap();
        CreateMap<Galaxy, UpdatedGalaxyResponse>().ReverseMap();
        CreateMap<Galaxy, DeleteGalaxyRequest>().ReverseMap();
        CreateMap<Galaxy, DeletedGalaxyResponse>().ReverseMap();
        CreateMap<Galaxy, GetGalaxyResponse>().ReverseMap();

        CreateMap<Galaxy, IGetGalaxyResponse>().As<GetGalaxyResponse>();

        CreateMap<ICollection<Galaxy>, GetAllGalaxyResponse>()
            .ForMember(dest => dest.Responses, opt => opt.MapFrom(src => src));
    }
}
