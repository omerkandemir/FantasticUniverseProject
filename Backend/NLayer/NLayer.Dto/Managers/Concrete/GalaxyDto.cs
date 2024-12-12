using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Galaxy;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Galaxy;

namespace NLayer.Dto.Managers.Concrete;

public class GalaxyDto : IGalaxyDto
{
    private readonly IGalaxyService _galaxyService;
    private readonly IMapper _mapper;
    public GalaxyDto(IGalaxyService galaxyService, IMapper mapper)
    {
        _galaxyService = galaxyService;
        _mapper = mapper;
    }
    public async Task<IResponse> AddAsync(CreateGalaxyRequest request)
    {
        Galaxy galaxy = _mapper.Map<Galaxy>(request);
        var result = await _galaxyService.AddAsync(galaxy);
        var response = _mapper.Map<CreatedGalaxyResponse>(galaxy);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Galaxy>(galaxy, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> UpdateAsync(UpdateGalaxyRequest request)
    {
        Galaxy galaxy = _mapper.Map<Galaxy>(request);
        var result = await _galaxyService.UpdateAsync(galaxy);
        var response = _mapper.Map<UpdatedGalaxyResponse>(galaxy);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Galaxy>(galaxy, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> DeleteAsync(DeleteGalaxyRequest request)
    {
        Galaxy galaxy = _mapper.Map<Galaxy>(request);
        var result = await _galaxyService.DeleteAsync(galaxy);
        var response = _mapper.Map<DeletedGalaxyResponse>(galaxy);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Galaxy>(galaxy, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public async Task<IGetGalaxyResponse> GetAsync(object id)
    {
        var value = await _galaxyService.GetAsync((int)id);
        var response = _mapper.Map<GetGalaxyResponse>(value.Data);
        return response;
    }

    public async Task<IGetAllResponse<IGetGalaxyResponse>> GetAllAsync()
    {
        var value = await _galaxyService.GetAllAsync();
        var response = _mapper.Map<GetAllGalaxyResponse>(value.Data);
        return response;
    }
}