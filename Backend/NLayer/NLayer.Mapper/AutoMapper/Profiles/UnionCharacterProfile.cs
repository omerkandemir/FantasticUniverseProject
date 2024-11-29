using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.UnionCharacter;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Adventure;
using NLayer.Mapper.Responses.Concrete.UnionCharacter;

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
        CreateMap<UnionCharacter, GetUnionCharacterResponse>().ReverseMap();
        CreateMap<UnionCharacter, GetAllUnionCharacterResponse>().ReverseMap();

        CreateMap<UnionCharacter, IGetUnionCharacterResponse>().As<GetUnionCharacterResponse>();

        CreateMap<ICollection<UnionCharacter>, GetAllUnionCharacterResponse>()
            .ForMember(dest => dest.Responses, opt => opt.MapFrom(src => src));
    }
}
