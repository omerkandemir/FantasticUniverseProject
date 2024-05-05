using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Adventure;
using NLayer.Mapper.Responses.Adventure;

namespace NLayer.Mapper.AutoMapper.Profiles;

public class AdventureProfile : Profile
{
    public AdventureProfile()
    {
        CreateMap<Adventure, CreateAdventureRequest>().ReverseMap();
        CreateMap<Adventure, CreatedAdventureResponse>().ReverseMap();
        CreateMap<Adventure, UpdateAdventureRequest>().ReverseMap();
        CreateMap<Adventure, UpdatedAdventureResponse>().ReverseMap();
        CreateMap<Adventure, DeleteAdventureRequest>().ReverseMap();
        CreateMap<Adventure, DeletedAdventureResponse>().ReverseMap();
        CreateMap<Adventure, GetAllAdventureResponse>().ReverseMap();
    }
}
