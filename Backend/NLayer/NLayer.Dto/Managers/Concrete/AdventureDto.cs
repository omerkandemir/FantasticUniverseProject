using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Adventure;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Adventure;

namespace NLayer.Dto.Managers.Concrete;

public class AdventureDto : IAdventureDto
{
    private readonly IAdventureService _adventureService;
    private readonly IMapper _mapper;
    public AdventureDto(IAdventureService adventureService, IMapper mapper)
    {
        _adventureService = adventureService;
        _mapper = mapper;
    }
    public async Task<IResponse> AddAsync(CreateAdventureRequest request)
    {
        Adventure adventure = _mapper.Map<Adventure>(request);
        var result = await _adventureService.AddAsync(adventure);
        var response = _mapper.Map<CreatedAdventureResponse>(adventure);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Adventure>(adventure, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> UpdateAsync(UpdateAdventureRequest request)
    {
        Adventure adventure = _mapper.Map<Adventure>(request);
        var result = await _adventureService.UpdateAsync(adventure);
        var response = _mapper.Map<UpdatedAdventureResponse>(adventure);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Adventure>(adventure, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> DeleteAsync(DeleteAdventureRequest request)
    {
        Adventure adventure = _mapper.Map<Adventure>(request);
        var result = await _adventureService.DeleteAsync(adventure);
        var response = _mapper.Map<DeletedAdventureResponse>(adventure);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Adventure>(adventure, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public async Task<IGetResponse> GetAsync(object id)
    {
        var value = await _adventureService.GetAsync(id);
        var response = _mapper.Map<GetAdventureResponse>(value.Data);
        return response;
    }

    public async Task<IGetAllResponse<IGetAdventureResponse>> GetAllAsync()
    {
        var value = await _adventureService.GetAllAsync();
        var response = _mapper.Map<GetAllAdventureResponse>(value.Data);
        return response;
    }
}
