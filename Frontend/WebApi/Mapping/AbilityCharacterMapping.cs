using AutoMapper;
using NLayer.Dto.Requests.AbilityCharacter;
using NLayer.Dto.Responses.AbilityCharacter;
using NLayer.Entities.Concretes;

namespace WebApi.Mapping;

public class AbilityCharacterMapping : Profile
{
    public AbilityCharacterMapping()
    {
        CreateMap<AbilityCharacter, CreateAbilityCharacterRequest>().ReverseMap();
        CreateMap<CreatedAbilityCharacterResponse, AbilityCharacter>().ReverseMap();
        CreateMap<AbilityCharacter, UpdateAbilityCharacterRequest>().ReverseMap();
        CreateMap<UpdatedAbilityCharacterResponse, AbilityCharacter>().ReverseMap();
        CreateMap<AbilityCharacter, DeleteAbilityCharacterRequest>().ReverseMap();
        CreateMap<DeletedAbilityCharacterResponse, AbilityCharacter>().ReverseMap();
        CreateMap<AbilityCharacter, GetAllAbilityCharacterResponse>().ReverseMap();
    }
}
