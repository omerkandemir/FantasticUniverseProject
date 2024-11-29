using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Character;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Adventure;
using NLayer.Mapper.Responses.Concrete.Character;

namespace NLayer.Mapper.AutoMapper.Profiles;

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
        CreateMap<Character, GetCharacterResponse>().ReverseMap();
        CreateMap<Character, GetAllCharacterResponse>().ReverseMap();

        CreateMap<Character, IGetCharacterResponse>().As<GetCharacterResponse>();

        CreateMap<ICollection<Character>, GetAllCharacterResponse>()
            .ForMember(dest => dest.Responses, opt => opt.MapFrom(src => src));
    }
}
