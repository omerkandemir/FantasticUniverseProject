using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Ability;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Ability;

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
    public async Task<IResponse> AddAsync(CreateAbilityRequest request)
    {
        Ability ability = _mapper.Map<Ability>(request);
        var result = await _abilityService.AddAsync(ability);
        var response = _mapper.Map<CreatedAbilityResponse>(ability);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Ability>(ability, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> UpdateAsync(UpdateAbilityRequest request)
    {
        Ability ability = _mapper.Map<Ability>(request);
        var result = await _abilityService.UpdateAsync(ability);
        var response = _mapper.Map<UpdatedAbilityResponse>(ability);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Ability>(ability, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> DeleteAsync(DeleteAbilityRequest request)
    {
        Ability ability = _mapper.Map<Ability>(request);
        var result = await _abilityService.DeleteAsync(ability);
        var response = _mapper.Map<DeletedAbilityResponse>(ability);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Ability>(ability, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public async Task<IGetResponse> GetAsync(object id)
    {
        var value = await _abilityService.GetAsync(id);
        var response = _mapper.Map<GetAbilityResponse>(value.Data);
        return response;
    }

    public async Task<IGetAllResponse<IGetAbilityResponse>> GetAllAsync()
    {
        var value = await _abilityService.GetAllAsync();
        var response = _mapper.Map<GetAllAbilityResponse>(value.Data);
        return response;
    }
}
