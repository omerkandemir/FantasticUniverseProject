using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Dto.Managers.Abstract;
using NLayer.Dto.Requests.Character;
using NLayer.Dto.Responses.Character;
using NLayer.Entities.Concretes;

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
    public ICreatedResponse Add(CreateCharacterRequest request)
    {
        var value = _mapper.Map<Character>(request);
        var x = _characterService.Add(value);
        var response = _mapper.Map<CreatedCharacterResponse>(value);
        return response;
    }
    public IUpdatedResponse Update(UpdateCharacterRequest request)
    {
        var value = _mapper.Map<Character>(request);
        _characterService.Update(value);
        var response = _mapper.Map<UpdatedCharacterResponse>(value);
        return response;
    }
    public IDeletedResponse Delete(DeleteCharacterRequest request)
    {
        var value = _mapper.Map<Character>(request);
        _characterService.Delete(value);
        var response = _mapper.Map<DeletedCharacterResponse>(value);
        return response;
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
