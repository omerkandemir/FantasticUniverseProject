using AutoMapper;
using NLayer.Dto.Requests.UnionCharacter;
using NLayer.Dto.Responses.UnionCharacter;
using NLayer.Entities.Concretes;

namespace WebApi.Mapping;

public class UnionCharacterMapping : Profile
{
    public UnionCharacterMapping()
    {
        CreateMap<UnionCharacter, CreateUnionCharacterRequest>().ReverseMap();
        CreateMap<CreatedUnionCharacterResponse, UnionCharacter>().ReverseMap();
        CreateMap<UnionCharacter, UpdateUnionCharacterRequest>().ReverseMap();
        CreateMap<UpdatedUnionCharacterResponse, UnionCharacter>().ReverseMap();
        CreateMap<UnionCharacter, DeleteUnionCharacterRequest>().ReverseMap();
        CreateMap<DeletedUnionCharacterResponse, UnionCharacter>().ReverseMap();
        CreateMap<UnionCharacter, GetAllUnionCharacterResponse>().ReverseMap();
    }
}
