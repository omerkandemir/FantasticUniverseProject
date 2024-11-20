using AutoMapper;
using NLayer.Core.Entities.Authentication;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Adventure;
using NLayer.Mapper.Responses.Concrete.AppUser;

namespace NLayer.Mapper.AutoMapper.Profiles;

public class AppUserProfile : Profile
{
    public AppUserProfile()
    {
        CreateMap<AppUser, CreateAppUserRequest>().ReverseMap();
        CreateMap<AppUser, CreatedAppUserResponse>().ReverseMap();
        CreateMap<AppUser, UpdateAppUserRequest>().ReverseMap();
        CreateMap<AppUser, UpdateAppUserInfoRequest>().ReverseMap();
        CreateMap<AppUser, UpdateAppUserEmailRequest>().ReverseMap();
        CreateMap<AppUser, UpdateAppUserPasswordRequest>().ReverseMap();
        CreateMap<AppUser, UpdateAppUserProfileImageRequest>().ReverseMap();
        CreateMap<AppUser, UpdatedAppUserResponse>().ReverseMap();
        CreateMap<AppUser, DeleteAppUserRequest>().ReverseMap();
        CreateMap<AppUser, DeletedAppUserResponse>().ReverseMap();
        CreateMap<AppUser, GetAppUserResponse>().ReverseMap();
        CreateMap<AppUser, GetAllAppUserResponse>().ReverseMap();
        CreateMap<AppUser, ConfirmMailRequest>().ReverseMap();
        CreateMap<AppUser, LoginRequest>().ReverseMap();

        CreateMap<AppUser, IGetAppUserResponse>().As<GetAppUserResponse>();

        CreateMap<ICollection<AppUser>, GetAllAppUserResponse>()
            .ForMember(dest => dest.Responses, opt => opt.MapFrom(src => src));

    }
}
