using AutoMapper;
using NLayer.Core.Entities.Authentication;
using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.AppUser;

namespace NLayer.Mapper.AutoMapper.Profiles;

public class AppUserProfile : Profile
{
    public AppUserProfile()
    {
        CreateMap<AppUser, CreateAppUserRequest>().ReverseMap();
        CreateMap<AppUser, CreatedAppUserResponse>().ReverseMap();
        CreateMap<AppUser, UpdateAppUserRequest>().ReverseMap();
        CreateMap<AppUser, UpdateAppUserInfoRequest>().ReverseMap();
        CreateMap<AppUser, UpdatedAppUserResponse>().ReverseMap();
        CreateMap<AppUser, DeleteAppUserRequest>().ReverseMap();
        CreateMap<AppUser, DeletedAppUserResponse>().ReverseMap();
        CreateMap<AppUser, GetAllAppUserResponse>().ReverseMap();
    }
}
