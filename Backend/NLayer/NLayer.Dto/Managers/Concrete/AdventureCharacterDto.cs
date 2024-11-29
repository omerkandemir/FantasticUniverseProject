using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.AdventureCharacter;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.AdventureCharacter;

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
    public async Task<IResponse> AddAsync(CreateAdventureCharacterRequest request)
    {
        AdventureCharacter adventureCharacter = _mapper.Map<AdventureCharacter>(request);
        var result =  await _adventureCharacterService.AddAsync(adventureCharacter);
        var response = _mapper.Map<CreatedAdventureCharacterResponse>(adventureCharacter);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<AdventureCharacter>(adventureCharacter, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> UpdateAsync(UpdateAdventureCharacterRequest request)
    {
        AdventureCharacter adventureCharacter = _mapper.Map<AdventureCharacter>(request);
        var result = await _adventureCharacterService.UpdateAsync(adventureCharacter);
        var response = _mapper.Map<UpdatedAdventureCharacterResponse>(adventureCharacter);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<AdventureCharacter>(adventureCharacter, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> DeleteAsync(DeleteAdventureCharacterRequest request)
    {
        AdventureCharacter adventureCharacter = _mapper.Map<AdventureCharacter>(request);
        var result = await _adventureCharacterService.DeleteAsync(adventureCharacter);
        var response = _mapper.Map<DeletedAdventureCharacterResponse>(adventureCharacter);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<AdventureCharacter>(adventureCharacter, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public async Task<IGetResponse> GetAsync(object id)
    {
        var value = await _adventureCharacterService.GetAsync(id);
        var response = _mapper.Map<GetAdventureCharacterResponse>(value.Data);
        return response;
    }

    public async Task<IGetAllResponse<IGetAdventureCharacterResponse>> GetAllAsync()
    {
        var value = await _adventureCharacterService.GetAllAsync();
        var response = _mapper.Map<GetAllAdventureCharacterResponse>(value.Data);
        return response;
    }
}
