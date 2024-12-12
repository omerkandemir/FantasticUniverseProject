using AutoMapper;
using NLayer.Core.Entities.Authorization;
using NLayer.Mapper.Requests.AppRole;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.AppRole;

namespace NLayer.Mapper.AutoMapper.Profiles;

public class AppRoleProfile : Profile
{
    public AppRoleProfile()
    {
        CreateMap<AppRole, CreateAppRoleRequest>().ReverseMap();
        CreateMap<AppRole, CreatedAppRoleResponse>().ReverseMap();
        CreateMap<AppRole, UpdateAppRoleRequest>().ReverseMap();
        CreateMap<AppRole, UpdatedAppRoleResponse>().ReverseMap();
        CreateMap<AppRole, DeleteAppRoleRequest>().ReverseMap();
        CreateMap<AppRole, DeleteConfirmationAppRoleRequest>().ReverseMap();
        CreateMap<AppRole, GetAppRoleResponse>().ReverseMap();
        CreateMap<AppRole, GetAllAppRoleResponse>().ReverseMap();


        CreateMap<AppRole, IGetAppRoleResponse>().As<GetAppRoleResponse>();

        CreateMap<ICollection<AppRole>, GetAllAppRoleResponse>()
            .ForMember(dest => dest.Responses, opt => opt.MapFrom(src => src));
    }
}