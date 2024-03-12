using AutoMapper;
using NLayer.Dto.Requests.Ability;
using NLayer.Dto.Responses.Ability;
using NLayer.Entities.Concretes;

namespace WebApi.Mapping;

public class AbilityMapping : Profile
{
    public AbilityMapping()
    {
        CreateMap<Ability, CreateAbilityRequest>().ReverseMap();
        CreateMap<CreatedAbilityResponse, Ability>().ReverseMap();
        CreateMap<Ability, UpdateAbilityRequest>().ReverseMap();
        CreateMap<UpdatedAbilityResponse, Ability>().ReverseMap();
        CreateMap<Ability, DeleteAbilityRequest>().ReverseMap();
        CreateMap<DeletedAbilityResponse, Ability>().ReverseMap();
        CreateMap<Ability, GetAllAbilityResponse>().ReverseMap();
    }
}
