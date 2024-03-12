using AutoMapper;
using NLayer.Dto.Requests.Union;
using NLayer.Dto.Responses.Union;
using NLayer.Entities.Concretes;

namespace WebApi.Mapping;

public class UnionMapping :  Profile
{
    public UnionMapping()
    {
        CreateMap<Union, CreateUnionRequest>().ReverseMap();
        CreateMap<CreatedUnionResponse, Union>().ReverseMap();
        CreateMap<Union, UpdateUnionRequest>().ReverseMap();
        CreateMap<UpdatedUnionResponse, Union>().ReverseMap();
        CreateMap<Union, DeleteUnionRequest>().ReverseMap();
        CreateMap<DeletedUnionResponse, Union>().ReverseMap();
        CreateMap<Union, GetAllUnionResponse>().ReverseMap();
    }
}
