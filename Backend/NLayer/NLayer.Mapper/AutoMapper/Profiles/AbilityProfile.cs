using AutoMapper;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Ability;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Ability;

namespace NLayer.Mapper.AutoMapper.Profiles;

public class AbilityProfile : Profile
{
    public AbilityProfile()
    {
        CreateMap<Ability, CreateAbilityRequest>().ReverseMap();
        CreateMap<Ability, CreatedAbilityResponse>().ReverseMap();
        CreateMap<Ability, UpdateAbilityRequest>().ReverseMap();
        CreateMap<Ability, UpdatedAbilityResponse>().ReverseMap();
        CreateMap<Ability, DeleteAbilityRequest>().ReverseMap();
        CreateMap<Ability, DeletedAbilityResponse>().ReverseMap();
        CreateMap<Ability, GetAbilityResponse>().ReverseMap();
        CreateMap<Ability, GetAllAbilityResponse>().ReverseMap();

        CreateMap<Ability, IGetAbilityResponse>().As<GetAbilityResponse>();

        CreateMap<ICollection<Ability>, GetAllAbilityResponse>()
            .ForMember(dest => dest.Responses, opt => opt.MapFrom(src => src));
    }
}
