using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.AbilityCharacter;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.AbilityCharacter;

namespace NLayer.Dto.Managers.Concrete;

public class AbilityCharacterDto : IAbilityCharacterDto
{
    private readonly IAbilityCharacterService _abilityCharacterService;
    private readonly IMapper _mapper;
    public AbilityCharacterDto(IAbilityCharacterService abilityCharacterService, IMapper mapper)
    {
        _abilityCharacterService = abilityCharacterService;
        _mapper = mapper;
    }
    public async Task<IResponse> AddAsync(CreateAbilityCharacterRequest request)
    {
        AbilityCharacter abilityCharacter = _mapper.Map<AbilityCharacter>(request);
        var result = await _abilityCharacterService.AddAsync(abilityCharacter);
        var response = _mapper.Map<CreatedAbilityCharacterResponse>(abilityCharacter);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<AbilityCharacter>(abilityCharacter, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> UpdateAsync(UpdateAbilityCharacterRequest request)
    {
        AbilityCharacter abilityCharacter = _mapper.Map<AbilityCharacter>(request);
        var result = await _abilityCharacterService.UpdateAsync(abilityCharacter);
        var response = _mapper.Map<UpdatedAbilityCharacterResponse>(abilityCharacter);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<AbilityCharacter>(abilityCharacter, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> DeleteAsync(DeleteAbilityCharacterRequest request)
    {
        AbilityCharacter abilityCharacter = _mapper.Map<AbilityCharacter>(request);
        var result = await _abilityCharacterService.DeleteAsync(abilityCharacter);
        var response = _mapper.Map<DeletedAbilityCharacterResponse>(abilityCharacter);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<AbilityCharacter>(abilityCharacter, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public async Task<IGetAbilityCharacterResponse> GetAsync(object id)
    {
        var value = await _abilityCharacterService.GetAsync((int)id);
        var response = _mapper.Map<GetAbilityCharacterResponse>(value.Data);
        return response;
    }

    public async Task<IGetAllResponse<IGetAbilityCharacterResponse>> GetAllAsync()
    {
        var value = await _abilityCharacterService.GetAllAsync();
        var response = _mapper.Map<GetAllAbilityCharacterResponse>(value.Data);
        return response;
    }
}
