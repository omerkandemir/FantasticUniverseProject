﻿using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
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
    public IResponse Add(CreateAdventureCharacterRequest request)
    {
        AdventureCharacter adventureCharacter = _mapper.Map<AdventureCharacter>(request);
        var result = _adventureCharacterService.Add(adventureCharacter);
        var response = _mapper.Map<CreatedAdventureCharacterResponse>(adventureCharacter);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<AdventureCharacter>(response, adventureCharacter);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IResponse Update(UpdateAdventureCharacterRequest request)
    {
        AdventureCharacter adventureCharacter = _mapper.Map<AdventureCharacter>(request);
        var result = _adventureCharacterService.Update(adventureCharacter);
        var response = _mapper.Map<UpdatedAdventureCharacterResponse>(adventureCharacter);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<AdventureCharacter>(response, adventureCharacter);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IResponse Delete(DeleteAdventureCharacterRequest request)
    {
        AdventureCharacter adventureCharacter = _mapper.Map<AdventureCharacter>(request);
        var result = _adventureCharacterService.Delete(adventureCharacter);
        var response = _mapper.Map<DeletedAdventureCharacterResponse>(adventureCharacter);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<AdventureCharacter>(response, adventureCharacter);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
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
