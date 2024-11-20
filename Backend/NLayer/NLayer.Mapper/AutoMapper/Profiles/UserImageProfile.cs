using AutoMapper;
using NLayer.Core.Entities.Concrete;
using NLayer.Mapper.Requests.UserImage;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.UserImage;

namespace NLayer.Mapper.AutoMapper.Profiles;

public class UserImageProfile : Profile
{
    public UserImageProfile()
    {
        CreateMap<UserImage, CreateUserImageRequest>().ReverseMap();
        CreateMap<UserImage, CreatedUserImageResponse>().ReverseMap();
        CreateMap<UserImage, UpdateUserImageRequest>().ReverseMap();
        CreateMap<UserImage, UpdatedUserImageResponse>().ReverseMap();
        CreateMap<UserImage, DeleteUserImageRequest>().ReverseMap();
        CreateMap<UserImage, DeletedUserImageResponse>().ReverseMap();
        CreateMap<UserImage, GetUserImageResponse>().ReverseMap();
        CreateMap<UserImage, GetAllUserImageResponse>().ReverseMap();

        CreateMap<UserImage, IGetUserImageResponse>().As<GetUserImageResponse>();

        CreateMap<ICollection<UserImage>, GetAllUserImageResponse>()
            .ForMember(dest => dest.Responses, opt => opt.MapFrom(src => src));
    }
}
