using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Planet;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Planet;

namespace NLayer.Dto.Managers.Concrete;

public class PlanetDto : IPlanetDto
{
    private readonly IPlanetService _planetService;
    private readonly IMapper _mapper;
    public PlanetDto(IPlanetService planetService, IMapper mapper)
    {
        _planetService = planetService;
        _mapper = mapper;
    }
    public async Task<IResponse> AddAsync(CreatePlanetRequest request)
    {
        Planet planet = _mapper.Map<Planet>(request);
        var result = await _planetService.AddAsync(planet);
        var response = _mapper.Map<CreatedPlanetResponse>(planet);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Planet>(planet, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> UpdateAsync(UpdatePlanetRequest request)
    {
        Planet planet = _mapper.Map<Planet>(request);
        var result = await _planetService.UpdateAsync(planet);
        var response = _mapper.Map<UpdatedPlanetResponse>(planet);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Planet>(planet, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> DeleteAsync(DeletePlanetRequest request)
    {
        Planet planet = _mapper.Map<Planet>(request);
        var result = await _planetService.DeleteAsync(planet);
        var response = _mapper.Map<DeletedPlanetResponse>(planet);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Planet>(planet, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public async Task<IGetResponse> GetAsync(object id)
    {
        var value = await _planetService.GetAsync(id);
        var response = _mapper.Map<GetPlanetResponse>(value.Data);
        return response;
    }

    public async Task<IGetAllResponse<IGetPlanetResponse>> GetAllAsync()
    {
        var value = await _planetService.GetAllAsync();
        var response = _mapper.Map<GetAllPlanetResponse>(value.Data);
        return response;
    }
}
