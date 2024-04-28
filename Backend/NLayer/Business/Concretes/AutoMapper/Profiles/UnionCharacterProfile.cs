using AutoMapper;
using NLayer.Dto.Requests.UnionCharacter;
using NLayer.Dto.Responses.UnionCharacter;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.AutoMapper.Profiles;

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
