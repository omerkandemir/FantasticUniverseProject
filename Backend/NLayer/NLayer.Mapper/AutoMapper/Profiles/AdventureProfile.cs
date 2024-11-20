using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Adventure;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.AbilityCharacter;
using NLayer.Mapper.Responses.Concrete.Adventure;

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
        CreateMap<Adventure, GetAdventureResponse>().ReverseMap();
        CreateMap<Adventure, GetAllAdventureResponse>().ReverseMap();

        CreateMap<Adventure, IGetAdventureResponse>().As<GetAdventureResponse>();

        CreateMap<ICollection<Adventure>, GetAllAdventureResponse>()
            .ForMember(dest => dest.Responses, opt => opt.MapFrom(src => src));
    }
}
