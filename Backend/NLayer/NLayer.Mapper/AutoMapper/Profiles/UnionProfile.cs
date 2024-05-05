using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Union;
using NLayer.Mapper.Responses.Union;

namespace NLayer.Mapper.AutoMapper.Profiles;

public class UnionProfile : Profile
{
    public UnionProfile()
    {
        CreateMap<Union, CreateUnionRequest>().ReverseMap();
        CreateMap<Union, CreatedUnionResponse>().ReverseMap();
        CreateMap<Union, UpdateUnionRequest>().ReverseMap();
        CreateMap<Union, UpdatedUnionResponse>().ReverseMap();
        CreateMap<Union, DeleteUnionRequest>().ReverseMap();
        CreateMap<Union, DeletedUnionResponse>().ReverseMap();
        CreateMap<Union, GetAllUnionResponse>().ReverseMap();
    }
}
