using AutoMapper;
using NLayer.Dto.Requests.Star;
using NLayer.Dto.Responses.Star;
using NLayer.Entities.Concretes;

namespace NLayer.Dto.AutoMapper.Profiles;

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
