using AutoMapper;
using NLayer.Dto.Requests.Ability;
using NLayer.Dto.Responses.Ability;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.AutoMapper.Profiles;

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
        CreateMap<Ability, GetAllAbilityResponse>().ReverseMap();
    }
}
