using AutoMapper;
using NLayer.Dto.Requests.AdventureCharacter;
using NLayer.Dto.Responses.AdventureCharacter;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.AutoMapper.Profiles;

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
