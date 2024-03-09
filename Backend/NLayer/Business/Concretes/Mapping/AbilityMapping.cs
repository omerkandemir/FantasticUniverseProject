using AutoMapper;
using NLayer.Dto.Requests.Ability;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Mapping;

public class AbilityMapping : Profile
{
    public AbilityMapping()
    {
        //CreateMap<Ability, UpdateAbilityRequest>().ReverseMap();
        //        CreateMap<Ability, CreateAbilityRequest>().ReverseMap();
        CreateMap<Ability, UpdateAbilityRequest>().ReverseMap().
            ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
.ForMember(dest => dest.UpdatedDate, opt => opt.Ignore())
.ForMember(dest => dest.IsActive, opt => opt.Ignore())
.ForMember(dest => dest.DeletedDate, opt => opt.Ignore());
        CreateMap<UpdateAbilityRequest, Ability>().ReverseMap().
            ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
.ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Name));
        //            ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        ////.ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
        //.ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src=>src.CreatedDate))
        //.ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => src.UpdatedDate)) // UpdatedDate için atama yapılmamış, ignore ediyoruz
        //.ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive)) // IsActive için atama yapılmamış, ignore ediyoruz
        //.ForMember(dest => dest.DeletedDate, opt => opt.MapFrom(src => src.DeletedDate)) // DeletedDate için atama yapılmamış, ignore ediyoruz
        //.ForMember(dest => dest.Characters, opt => opt.Ignore()); ;
        //        CreateMap<Ability, DeleteAbilityRequest>().ReverseMap();
        //        CreateMap<Ability, GetAllAbilityResponse>().ReverseMap()
        //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
        ////.ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
        //.ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
        //.ForMember(dest => dest.UpdatedDate, opt => opt.Ignore()) // UpdatedDate için atama yapılmamış, ignore ediyoruz
        //.ForMember(dest => dest.IsActive, opt => opt.Ignore()) // IsActive için atama yapılmamış, ignore ediyoruz
        //.ForMember(dest => dest.DeletedDate, opt => opt.Ignore()) // DeletedDate için atama yapılmamış, ignore ediyoruz
        //.ForMember(dest => dest.Characters, opt => opt.Ignore());
    }
}
