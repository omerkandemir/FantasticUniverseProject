using AutoMapper;
using NLayer.Dto.Requests.Star;
using NLayer.Dto.Responses.Star;
using NLayer.Entities.Concretes;

namespace WebApi.Mapping;

public class StarMapping : Profile
{
    public StarMapping()
    {
        CreateMap<Star, CreateStarRequest>().ReverseMap();
        CreateMap<CreatedStarResponse, Star>().ReverseMap();
        CreateMap<Star, UpdateStarRequest>().ReverseMap();
        CreateMap<UpdatedStarResponse, Star>().ReverseMap();
        CreateMap<Star, DeleteStarRequest>().ReverseMap();
        CreateMap<DeletedStarResponse, Star>().ReverseMap();
        CreateMap<Star, GetAllStarResponse>().ReverseMap();
    }
}
