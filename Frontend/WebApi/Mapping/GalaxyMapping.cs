using AutoMapper;
using NLayer.Dto.Requests.Galaxy;
using NLayer.Dto.Responses.Galaxy;
using NLayer.Entities.Concretes;

namespace WebApi.Mapping;

public class GalaxyMapping : Profile
{
    public GalaxyMapping()
    {
        CreateMap<Galaxy, CreateGalaxyRequest>().ReverseMap();
        CreateMap<CreatedGalaxyResponse, Galaxy>().ReverseMap();
        CreateMap<Galaxy, UpdateGalaxyRequest>().ReverseMap();
        CreateMap<UpdatedGalaxyResponse, Galaxy>().ReverseMap();
        CreateMap<Galaxy, DeleteGalaxyRequest>().ReverseMap();
        CreateMap<DeletedGalaxyResponse, Galaxy>().ReverseMap();
        CreateMap<Galaxy, GetAllGalaxyResponse>().ReverseMap();
    }
}
