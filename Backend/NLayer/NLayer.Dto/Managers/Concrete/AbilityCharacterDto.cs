using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.AbilityCharacter;
using NLayer.Mapper.Responses.AbilityCharacter;

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
    public IResponse Add(CreateAbilityCharacterRequest request)
    {
        AbilityCharacter abilityCharacter = _mapper.Map<AbilityCharacter>(request);
        var result = _abilityCharacterService.Add(abilityCharacter);
        var response = _mapper.Map<CreatedAbilityCharacterResponse>(abilityCharacter);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<AbilityCharacter>(response, abilityCharacter);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IResponse Update(UpdateAbilityCharacterRequest request)
    {
        AbilityCharacter abilityCharacter = _mapper.Map<AbilityCharacter>(request);
        var result = _abilityCharacterService.Update(abilityCharacter);
        var response = _mapper.Map<UpdatedAbilityCharacterResponse>(abilityCharacter);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<AbilityCharacter>(response, abilityCharacter);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IResponse Delete(DeleteAbilityCharacterRequest request)
    {
        AbilityCharacter abilityCharacter = _mapper.Map<AbilityCharacter>(request);
        var result = _abilityCharacterService.Delete(abilityCharacter);
        var response = _mapper.Map<DeletedAbilityCharacterResponse>(abilityCharacter);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<AbilityCharacter>(response, abilityCharacter);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public IGetResponse Get(object id)
    {
        var value = _abilityCharacterService.Get(id);
        var response = _mapper.Map<GetAllAbilityCharacterResponse>(value.Data);
        return response;
    }

    public List<GetAllAbilityCharacterResponse> GetAll()
    {
        var value = _abilityCharacterService.GetAll();
        var response = _mapper.Map<List<GetAllAbilityCharacterResponse>>(value.Data);
        return response;
    }
}
