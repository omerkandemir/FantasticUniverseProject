using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.AbilityCharacter;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.AbilityCharacter;

namespace NLayer.Mapper.AutoMapper.Profiles;

public class AbilityCharacterProfile : Profile
{
    public AbilityCharacterProfile()
    {
        CreateMap<AbilityCharacter, CreateAbilityCharacterRequest>().ReverseMap();
        CreateMap<AbilityCharacter, CreatedAbilityCharacterResponse>().ReverseMap();
        CreateMap<AbilityCharacter, UpdateAbilityCharacterRequest>().ReverseMap();
        CreateMap<AbilityCharacter, UpdatedAbilityCharacterResponse>().ReverseMap();
        CreateMap<AbilityCharacter, DeleteAbilityCharacterRequest>().ReverseMap();
        CreateMap<AbilityCharacter, DeletedAbilityCharacterResponse>().ReverseMap();
        CreateMap<AbilityCharacter, GetAbilityCharacterResponse>().ReverseMap();
        CreateMap<AbilityCharacter, GetAllAbilityCharacterResponse>().ReverseMap();

        CreateMap<AbilityCharacter, IGetAbilityCharacterResponse>().As<GetAbilityCharacterResponse>();

        CreateMap<ICollection<AbilityCharacter>, GetAllAbilityCharacterResponse>()
            .ForMember(dest => dest.Responses, opt => opt.MapFrom(src => src));
    }
}
