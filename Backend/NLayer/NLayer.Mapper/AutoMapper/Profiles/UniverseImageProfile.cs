using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.UniverseImage;
using NLayer.Mapper.Responses.UniverseImage;

namespace NLayer.Mapper.AutoMapper.Profiles
{
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
            CreateMap<UniverseImage, GetAllUniverseImageResponse>().ReverseMap();
        }
    }
}
