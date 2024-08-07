﻿using AutoMapper;
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
    public IErrorResponse Add(CreateCharacterRequest request)
    {
        var value = _mapper.Map<Character>(request);
        var result = _characterService.Add(value);
        var response = _mapper.Map<CreatedCharacterResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IErrorResponse Update(UpdateCharacterRequest request)
    {
        var value = _mapper.Map<Character>(request);
        var result = _characterService.Update(value);
        var response = _mapper.Map<UpdatedCharacterResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IErrorResponse Delete(DeleteCharacterRequest request)
    {
        var value = _mapper.Map<Character>(request);
        var result = _characterService.Delete(value);
        var response = _mapper.Map<DeletedCharacterResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
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
