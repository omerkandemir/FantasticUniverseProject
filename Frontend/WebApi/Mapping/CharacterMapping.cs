using AutoMapper;
using NLayer.Dto.Requests.Character;
using NLayer.Dto.Responses.Character;
using NLayer.Entities.Concretes;

namespace WebApi.Mapping;

public class CharacterMapping : Profile
{
    public CharacterMapping()
    {
        CreateMap<Character, CreateCharacterRequest>().ReverseMap();
        CreateMap<CreatedCharacterResponse, Character>().ReverseMap();
        CreateMap<Character, UpdateCharacterRequest>().ReverseMap();
        CreateMap<UpdatedCharacterResponse, Character>().ReverseMap();
        CreateMap<Character, DeleteCharacterRequest>().ReverseMap();
        CreateMap<DeletedCharacterResponse, Character>().ReverseMap();
        CreateMap<Character, GetAllCharacterResponse>().ReverseMap();
    }
}
