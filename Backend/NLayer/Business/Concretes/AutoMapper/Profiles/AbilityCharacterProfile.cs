using AutoMapper;
using NLayer.Dto.Requests.AbilityCharacter;
using NLayer.Dto.Responses.AbilityCharacter;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.AutoMapper.Profiles;

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
