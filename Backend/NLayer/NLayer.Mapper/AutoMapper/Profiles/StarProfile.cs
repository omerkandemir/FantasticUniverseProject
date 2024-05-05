using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Star;
using NLayer.Mapper.Responses.Star;

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
        CreateMap<Star, GetAllStarResponse>().ReverseMap();
    }
}
