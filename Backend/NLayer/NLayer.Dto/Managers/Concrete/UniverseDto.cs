using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Universe;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Universe;

namespace NLayer.Dto.Managers.Concrete;

public class UniverseDto : IUniverseDto
{
    private readonly IUniverseService _universeService;
    private readonly IMapper _mapper;
    public UniverseDto(IUniverseService universeService, IMapper mapper)
    {
        _universeService = universeService;
        _mapper = mapper;
    }
    public async Task<IResponse> AddAsync(CreateUniverseRequest request)
    {
        Universe universe = _mapper.Map<Universe>(request);
        var result = await _universeService.AddAsync(universe);
        var response = _mapper.Map<CreatedUniverseResponse>(universe);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Universe>(universe, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public async Task<IResponse> CreateUniverseAsync(CreateUniverseRequest request)
    {
        Universe universe = _mapper.Map<Universe>(request);
        var result = await _universeService.CreateUniverseAsync(universe);
        var response = _mapper.Map<CreatedUniverseResponse>(universe);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Universe>(universe, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public async Task<IResponse> UpdateAsync(UpdateUniverseRequest request)
    {
        Universe universe = _mapper.Map<Universe>(request);
        var result = await _universeService.UpdateAsync(universe);
        var response = _mapper.Map<UpdatedUniverseResponse>(universe);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Universe>(universe, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> DeleteAsync(DeleteUniverseRequest request)
    {
        Universe universe = _mapper.Map<Universe>(request);
        var result = await _universeService.DeleteAsync(universe);
        var response = _mapper.Map<DeletedUniverseResponse>(universe);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Universe>(universe, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public async Task<IGetResponse> GetAsync(object id)
    {
        var value = await _universeService.GetAsync(id);
        var response = _mapper.Map<GetUniverseResponse>(value.Data);
        return response;
    }

    public async Task<IGetAllResponse<IGetUniverseResponse>> GetAllAsync()
    {
        var value = await _universeService.GetAllAsync();
        var response = _mapper.Map<GetAllUniverseResponse>(value.Data);
        return response;
    }

    public async Task<IGetResponse> GetUniverseDetailAsync(int id)
    {
        var value = await _universeService.GetAsync(id);
        var response = _mapper.Map<GetUniverseResponse>(value.Data);
        return response;
    }

    public async Task<IGetAllResponse<IGetUniverseResponse>> GetUserUniversesAsync(int userId)
    {
        var value = await _universeService.GetUserUniversesAsync(userId);
        var response = _mapper.Map<GetAllUniverseResponse>(value.Data);
        return response;
    }
}
