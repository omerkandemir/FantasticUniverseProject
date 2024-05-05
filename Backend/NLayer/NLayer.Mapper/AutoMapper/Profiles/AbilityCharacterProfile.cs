using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.AbilityCharacter;
using NLayer.Mapper.Responses.AbilityCharacter;

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
        CreateMap<AbilityCharacter, GetAllAbilityCharacterResponse>().ReverseMap();
    }
}
