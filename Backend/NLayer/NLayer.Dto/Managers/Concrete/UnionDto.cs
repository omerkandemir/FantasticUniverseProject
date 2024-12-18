﻿using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Union;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Union;

namespace NLayer.Dto.Managers.Concrete;

public class UnionDto : IUnionDto
{
    private readonly IUnionService _unionService;
    private readonly IMapper _mapper;
    public UnionDto(IUnionService unionService, IMapper mapper)
    {
        _unionService = unionService;
        _mapper = mapper;
    }
    public async Task<IResponse> AddAsync(CreateUnionRequest request)
    {
        Union union = _mapper.Map<Union>(request);
        var result = await _unionService.AddAsync(union);
        var response = _mapper.Map<CreatedUnionResponse>(union);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Union>(union, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> UpdateAsync(UpdateUnionRequest request)
    {
        Union union = _mapper.Map<Union>(request);
        var result = await _unionService.UpdateAsync(union);
        var response = _mapper.Map<UpdatedUnionResponse>(union);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Union>(union, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> DeleteAsync(DeleteUnionRequest request)
    {
        Union union = _mapper.Map<Union>(request);
        var result = await _unionService.DeleteAsync(union);
        var response = _mapper.Map<DeletedUnionResponse>(union);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Union>(union, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public async Task<IGetUnionResponse> GetAsync(object id)
    {
        var value = await _unionService.GetAsync((int)id);
        var response = _mapper.Map<GetUnionResponse>(value.Data);
        return response;
    }

    public async Task<IGetAllResponse<IGetUnionResponse>> GetAllAsync()
    {
        var value = await _unionService.GetAllAsync();
        var response = _mapper.Map<GetAllUnionResponse>(value.Data);
        return response;
    }
}
