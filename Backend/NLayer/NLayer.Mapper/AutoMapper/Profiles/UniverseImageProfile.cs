using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.UniverseImage;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Adventure;
using NLayer.Mapper.Responses.Concrete.UniverseImage;

namespace NLayer.Mapper.AutoMapper.Profiles;

public class UniverseImageProfile : Profile
{
    public UniverseImageProfile()
    {
        CreateMap<UniverseImage, CreateUniverseImageRequest>().ReverseMap();
        CreateMap<UniverseImage, CreatedUniverseImageResponse>().ReverseMap();
        CreateMap<UniverseImage, UpdateUniverseImageRequest>().ReverseMap();
        CreateMap<UniverseImage, UpdatedUniverseImageResponse>().ReverseMap();
        CreateMap<UniverseImage, DeleteUniverseImageRequest>().ReverseMap();
        CreateMap<UniverseImage, DeletedUniverseImageResponse>().ReverseMap();
        CreateMap<UniverseImage, GetUniverseImageResponse>().ReverseMap();
        CreateMap<UniverseImage, GetAllUniverseImageResponse>().ReverseMap();

        CreateMap<UniverseImage, IGetUniverseImageResponse>().As<GetUniverseImageResponse>();

        CreateMap<ICollection<UniverseImage>, GetAllUniverseImageResponse>()
            .ForMember(dest => dest.Responses, opt => opt.MapFrom(src => src));
    }
}
