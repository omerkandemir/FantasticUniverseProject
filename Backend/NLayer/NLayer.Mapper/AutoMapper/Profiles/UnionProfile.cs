using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Union;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Adventure;
using NLayer.Mapper.Responses.Concrete.Union;

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
        CreateMap<Union, GetUnionResponse>().ReverseMap();
        CreateMap<Union, GetAllUnionResponse>().ReverseMap();

        CreateMap<Union, IGetUnionResponse>().As<GetUnionResponse>();

        CreateMap<ICollection<Union>, GetAllUnionResponse>()
            .ForMember(dest => dest.Responses, opt => opt.MapFrom(src => src));
    }
}
