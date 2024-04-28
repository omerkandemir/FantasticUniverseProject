using AutoMapper;
using NLayer.Dto.Requests.Union;
using NLayer.Dto.Responses.Union;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.AutoMapper.Profiles;

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
