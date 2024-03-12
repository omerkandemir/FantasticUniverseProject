using AutoMapper;
using NLayer.Dto.Requests.AdventureCharacter;
using NLayer.Dto.Responses.AdventureCharacter;
using NLayer.Entities.Concretes;

namespace WebApi.Mapping;

public class AdventureCharacterMapping : Profile
{
    public AdventureCharacterMapping()
    {
        CreateMap<AdventureCharacter, CreateAdventureCharacterRequest>().ReverseMap();
        CreateMap<CreatedAdventureCharacterResponse, AdventureCharacter>().ReverseMap();
        CreateMap<AdventureCharacter, UpdateAdventureCharacterRequest>().ReverseMap();
        CreateMap<UpdatedAdventureCharacterResponse, AdventureCharacter>().ReverseMap();
        CreateMap<AdventureCharacter, DeleteAdventureCharacterRequest>().ReverseMap();
        CreateMap<DeletedAdventureCharacterResponse, AdventureCharacter>().ReverseMap();
        CreateMap<AdventureCharacter, GetAllAdventureCharacterResponse>().ReverseMap();
    }
}
