﻿using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Character;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Character;

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
    public async Task<IResponse> AddAsync(CreateCharacterRequest request)
    {
        Character character = _mapper.Map<Character>(request);
        var result = await _characterService.AddAsync(character);
        var response = _mapper.Map<CreatedCharacterResponse>(character);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Character>(character, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> UpdateAsync(UpdateCharacterRequest request)
    {
        Character character = _mapper.Map<Character>(request);
        var result = await _characterService.UpdateAsync(character);
        var response = _mapper.Map<UpdatedCharacterResponse>(character);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Character>(character, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> DeleteAsync(DeleteCharacterRequest request)
    {
        Character character = _mapper.Map<Character>(request);
        var result = await _characterService.DeleteAsync(character);
        var response = _mapper.Map<DeletedCharacterResponse>(character);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Character>(character, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public async Task<IGetCharacterResponse> GetAsync(object id)
    {
        var value = await _characterService.GetAsync((int)id);
        var response = _mapper.Map<GetCharacterResponse>(value.Data);
        return response;
    }

    public async Task<IGetAllResponse<IGetCharacterResponse>> GetAllAsync()
    {
        var value = await _characterService.GetAllAsync();
        var response = _mapper.Map<GetAllCharacterResponse>(value.Data);
        return response;
    }
}
