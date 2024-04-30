using AutoMapper;
using NLayer.Dto.Requests.Galaxy;
using NLayer.Dto.Responses.Galaxy;
using NLayer.Entities.Concretes;

namespace NLayer.Dto.AutoMapper.Profiles;

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
        CreateMap<Galaxy, GetAllGalaxyResponse>().ReverseMap();
    }
}
