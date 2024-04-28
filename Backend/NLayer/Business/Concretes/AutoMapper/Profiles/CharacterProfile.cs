using AutoMapper;
using NLayer.Dto.Requests.Character;
using NLayer.Dto.Responses.Character;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.AutoMapper.Profiles;

public class CharacterProfile : Profile
{
    public CharacterProfile()
    {
        CreateMap<Character, CreateCharacterRequest>().ReverseMap();
        CreateMap<Character, CreatedCharacterResponse>().ReverseMap();
        CreateMap<Character, UpdateCharacterRequest>().ReverseMap();
        CreateMap<Character, UpdatedCharacterResponse>().ReverseMap();
        CreateMap<Character, DeleteCharacterRequest>().ReverseMap();
        CreateMap<Character, DeletedCharacterResponse>().ReverseMap();
        CreateMap<Character, GetAllCharacterResponse>().ReverseMap();
    }
}
