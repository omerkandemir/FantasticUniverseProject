using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Dto.Managers.Abstract;
using NLayer.Dto.Requests.Ability;
using NLayer.Dto.Responses.Ability;
using NLayer.Entities.Concretes;

namespace NLayer.Dto.Managers.Concrete;

public class AbilityDto : IAbilityDto
{
    private readonly IAbilityService _abilityService;
    private readonly IMapper _mapper;
    public AbilityDto(IAbilityService abilityService,IMapper mapper)
    {
        _abilityService = abilityService;
        _mapper = mapper;
    }
    public ICreatedResponse Add(CreateAbilityRequest request)
    {
        var value = _mapper.Map<Ability>(request);
        _abilityService.Add(value);
        var response = _mapper.Map<CreatedAbilityResponse>(value);
        return response;
    }
    public IUpdatedResponse Update(UpdateAbilityRequest request)
    {
        var value = _mapper.Map<Ability>(request);
        _abilityService.Update(value);
        var response = _mapper.Map<UpdatedAbilityResponse>(value);
        return response;
    }
    public IDeletedResponse Delete(DeleteAbilityRequest request)
    {
        var value = _mapper.Map<Ability>(request);
        _abilityService.Delete(value);
        var response = _mapper.Map<DeletedAbilityResponse>(value);
        return response;
    }

    public IGetResponse Get(object id)
    {
        var value = _abilityService.Get(id);
        var response = _mapper.Map<GetAllAbilityResponse>(value.Data);
        return response;
    }

    public List<GetAllAbilityResponse> GetAll()
    {
        var value = _abilityService.GetAll();
        var response = _mapper.Map<List<GetAllAbilityResponse>>(value.Data);
        return response;
    }
}
