using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Star;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Adventure;
using NLayer.Mapper.Responses.Concrete.Star;

namespace NLayer.Mapper.AutoMapper.Profiles;

public class StarProfile : Profile
{
    public StarProfile()
    {
        CreateMap<Star, CreateStarRequest>().ReverseMap();
        CreateMap<Star, CreatedStarResponse>().ReverseMap();
        CreateMap<Star, UpdateStarRequest>().ReverseMap();
        CreateMap<Star, UpdatedStarResponse>().ReverseMap();
        CreateMap<Star, DeleteStarRequest>().ReverseMap();
        CreateMap<Star, DeletedStarResponse>().ReverseMap();
        CreateMap<Star, GetStarResponse>().ReverseMap();
        CreateMap<Star, GetAllStarResponse>().ReverseMap();

        CreateMap<Star, IGetStarResponse>().As<GetStarResponse>();

        CreateMap<ICollection<Star>, GetAllStarResponse>()
            .ForMember(dest => dest.Responses, opt => opt.MapFrom(src => src));
    }
}
