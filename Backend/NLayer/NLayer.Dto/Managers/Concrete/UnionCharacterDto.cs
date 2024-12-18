﻿using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.UnionCharacter;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.UnionCharacter;

namespace NLayer.Dto.Managers.Concrete;

public class UnionCharacterDto : IUnionCharacterDto
{
    private readonly IUnionCharacterService _unionCharacterService;
    private readonly IMapper _mapper;
    public UnionCharacterDto(IUnionCharacterService unionCharacterService, IMapper mapper)
    {
        _unionCharacterService = unionCharacterService;
        _mapper = mapper;
    }
    public async Task<IResponse> AddAsync(CreateUnionCharacterRequest request)
    {
        UnionCharacter unionCharacter = _mapper.Map<UnionCharacter>(request);
        var result = await _unionCharacterService.AddAsync(unionCharacter);
        var response = _mapper.Map<CreatedUnionCharacterResponse>(unionCharacter);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<UnionCharacter>(unionCharacter, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> UpdateAsync(UpdateUnionCharacterRequest request)
    {
        UnionCharacter unionCharacter = _mapper.Map<UnionCharacter>(request);
        var result = await _unionCharacterService.UpdateAsync(unionCharacter);
        var response = _mapper.Map<UpdatedUnionCharacterResponse>(unionCharacter);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<UnionCharacter>(unionCharacter, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> DeleteAsync(DeleteUnionCharacterRequest request)
    {
        UnionCharacter unionCharacter = _mapper.Map<UnionCharacter>(request);
        var result = await _unionCharacterService.DeleteAsync(unionCharacter);
        var response = _mapper.Map<DeletedUnionCharacterResponse>(unionCharacter);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<UnionCharacter>(unionCharacter, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public async Task<IGetUnionCharacterResponse> GetAsync(object id)
    {
        var value = await _unionCharacterService.GetAsync((int)id);
        var response = _mapper.Map<GetUnionCharacterResponse>(value.Data);
        return response;
    }

    public async Task<IGetAllResponse<IGetUnionCharacterResponse>> GetAllAsync()
    {
        var value = await _unionCharacterService.GetAllAsync();
        var response = _mapper.Map<GetAllUnionCharacterResponse>(value.Data);
        return response;
    }
}
