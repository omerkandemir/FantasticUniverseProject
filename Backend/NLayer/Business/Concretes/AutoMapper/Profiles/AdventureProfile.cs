using AutoMapper;
using NLayer.Dto.Requests.Adventure;
using NLayer.Dto.Responses.Adventure;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.AutoMapper.Profiles;

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
