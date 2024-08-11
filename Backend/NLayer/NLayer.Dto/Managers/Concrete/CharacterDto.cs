using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Character;
using NLayer.Mapper.Responses.Character;

namespace NLayer.Dto.Managers.Concrete;

public class CharacterDto : ICharacterDto
{
    private readonly ICharacterService _characterService;
    private readonly IMapper _mapper;
    public CharacterDto(ICharacterService characterService, IMapper mapper)
    {
        _characterService = characterService;
        _mapper = mapper;
    }
    public IResponse Add(CreateCharacterRequest request)
    {
        Character character = _mapper.Map<Character>(request);
        var result = _characterService.Add(character);
        var response = _mapper.Map<CreatedCharacterResponse>(character);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Character>(response, character);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IResponse Update(UpdateCharacterRequest request)
    {
        Character character = _mapper.Map<Character>(request);
        var result = _characterService.Update(character);
        var response = _mapper.Map<UpdatedCharacterResponse>(character);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Character>(response, character);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IResponse Delete(DeleteCharacterRequest request)
    {
        Character character = _mapper.Map<Character>(request);
        var result = _characterService.Delete(character);
        var response = _mapper.Map<DeletedCharacterResponse>(character);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Character>(response, character);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public IGetResponse Get(object id)
    {
        var value = _characterService.Get(id);
        var response = _mapper.Map<GetAllCharacterResponse>(value.Data);
        return response;
    }

    public List<GetAllCharacterResponse> GetAll()
    {
        var value = _characterService.GetAll();
        var response = _mapper.Map<List<GetAllCharacterResponse>>(value.Data);
        return response;
    }
}
