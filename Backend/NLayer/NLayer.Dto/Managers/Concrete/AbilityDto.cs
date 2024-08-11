using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Ability;
using NLayer.Mapper.Responses.Ability;

namespace NLayer.Dto.Managers.Concrete;

public class AbilityDto : IAbilityDto
{
    private readonly IAbilityService _abilityService;
    private readonly IMapper _mapper;
    public AbilityDto(IAbilityService abilityService, IMapper mapper)
    {
        _abilityService = abilityService;
        _mapper = mapper;
    }
    public IResponse Add(CreateAbilityRequest request)
    {
        Ability ability = _mapper.Map<Ability>(request);
        var result = _abilityService.Add(ability);
        var response = _mapper.Map<CreatedAbilityResponse>(ability);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Ability>(response, ability);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IResponse Update(UpdateAbilityRequest request)
    {
        Ability ability = _mapper.Map<Ability>(request);
        var result = _abilityService.Update(ability);
        var response = _mapper.Map<UpdatedAbilityResponse>(ability);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Ability>(response, ability);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IResponse Delete(DeleteAbilityRequest request)
    {
        Ability ability = _mapper.Map<Ability>(request);
        var result = _abilityService.Delete(ability);
        var response = _mapper.Map<DeletedAbilityResponse>(ability);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Ability>(response, ability);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
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
