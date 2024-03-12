using AutoMapper;
using NLayer.Dto.Requests.Adventure;
using NLayer.Dto.Responses.Adventure;
using NLayer.Entities.Concretes;

namespace WebApi.Mapping;

public class AdventureMapping : Profile
{
    public AdventureMapping()
    {
        CreateMap<Adventure, CreateAdventureRequest>().ReverseMap();
        CreateMap<CreatedAdventureResponse, Adventure>().ReverseMap();
        CreateMap<Adventure, UpdateAdventureRequest>().ReverseMap();
        CreateMap<UpdatedAdventureResponse, Adventure>().ReverseMap();
        CreateMap<Adventure, DeleteAdventureRequest>().ReverseMap();
        CreateMap<DeletedAdventureResponse, Adventure>().ReverseMap();
        CreateMap<Adventure, GetAllAdventureResponse>().ReverseMap();
    }
}
