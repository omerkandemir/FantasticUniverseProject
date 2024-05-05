using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.UnionCharacter;
using NLayer.Mapper.Responses.UnionCharacter;

namespace NLayer.Mapper.AutoMapper.Profiles;

public class UnionCharacterProfile : Profile
{
    public UnionCharacterProfile()
    {
        CreateMap<UnionCharacter, CreateUnionCharacterRequest>().ReverseMap();
        CreateMap<UnionCharacter, CreatedUnionCharacterResponse>().ReverseMap();
        CreateMap<UnionCharacter, UpdateUnionCharacterRequest>().ReverseMap();
        CreateMap<UnionCharacter, UpdatedUnionCharacterResponse>().ReverseMap();
        CreateMap<UnionCharacter, DeleteUnionCharacterRequest>().ReverseMap();
        CreateMap<UnionCharacter, DeletedUnionCharacterResponse>().ReverseMap();
        CreateMap<UnionCharacter, GetAllUnionCharacterResponse>().ReverseMap();
    }
}
