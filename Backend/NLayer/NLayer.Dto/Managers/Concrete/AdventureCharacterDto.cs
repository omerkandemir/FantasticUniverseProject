using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.AdventureCharacter;
using NLayer.Mapper.Responses.AdventureCharacter;

namespace NLayer.Dto.Managers.Concrete;

public class AdventureCharacterDto : IAdventureCharacterDto
{
    private readonly IAdventureCharacterService _adventureCharacterService;
    private readonly IMapper _mapper;
    public AdventureCharacterDto(IAdventureCharacterService adventureCharacterService, IMapper mapper)
    {
        _adventureCharacterService = adventureCharacterService;
        _mapper = mapper;
    }
    public ICreatedResponse Add(CreateAdventureCharacterRequest request)
    {
        var value = _mapper.Map<AdventureCharacter>(request);
        _adventureCharacterService.Add(value);
        var response = _mapper.Map<CreatedAdventureCharacterResponse>(value);
        return response;
    }
    public IUpdatedResponse Update(UpdateAdventureCharacterRequest request)
    {
        var value = _mapper.Map<AdventureCharacter>(request);
        _adventureCharacterService.Update(value);
        var response = _mapper.Map<UpdatedAdventureCharacterResponse>(value);
        return response;
    }
    public IDeletedResponse Delete(DeleteAdventureCharacterRequest request)
    {
        var value = _mapper.Map<AdventureCharacter>(request);
        _adventureCharacterService.Delete(value);
        var response = _mapper.Map<DeletedAdventureCharacterResponse>(value);
        return response;
    }

    public IGetResponse Get(object id)
    {
        var value = _adventureCharacterService.Get(id);
        var response = _mapper.Map<GetAllAdventureCharacterResponse>(value.Data);
        return response;
    }

    public List<GetAllAdventureCharacterResponse> GetAll()
    {
        var value = _adventureCharacterService.GetAll();
        var response = _mapper.Map<List<GetAllAdventureCharacterResponse>>(value.Data);
        return response;
    }
}
