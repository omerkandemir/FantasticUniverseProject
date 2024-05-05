using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.AdventureCharacter;
using NLayer.Mapper.Responses.AdventureCharacter;

namespace NLayer.Mapper.AutoMapper.Profiles;

public class AdventureCharacterProfile : Profile
{
    public AdventureCharacterProfile()
    {
        CreateMap<AdventureCharacter, CreateAdventureCharacterRequest>().ReverseMap();
        CreateMap<AdventureCharacter, CreatedAdventureCharacterResponse>().ReverseMap();
        CreateMap<AdventureCharacter, UpdateAdventureCharacterRequest>().ReverseMap();
        CreateMap<AdventureCharacter, UpdatedAdventureCharacterResponse>().ReverseMap();
        CreateMap<AdventureCharacter, DeleteAdventureCharacterRequest>().ReverseMap();
        CreateMap<AdventureCharacter, DeletedAdventureCharacterResponse>().ReverseMap();
        CreateMap<AdventureCharacter, GetAllAdventureCharacterResponse>().ReverseMap();
    }
}
