using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Planet;
using NLayer.Mapper.Responses.Planet;

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
    public IResponse Add(CreatePlanetRequest request)
    {
        Planet planet = _mapper.Map<Planet>(request);
        var result = _planetService.Add(planet);
        var response = _mapper.Map<CreatedPlanetResponse>(planet);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Planet>(response, planet);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IResponse Update(UpdatePlanetRequest request)
    {
        Planet planet = _mapper.Map<Planet>(request);
        var result = _planetService.Update(planet);
        var response = _mapper.Map<UpdatedPlanetResponse>(planet);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Planet>(response, planet);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IResponse Delete(DeletePlanetRequest request)
    {
        Planet planet = _mapper.Map<Planet>(request);
        var result = _planetService.Delete(planet);
        var response = _mapper.Map<DeletedPlanetResponse>(planet);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Planet>(response, planet);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public IGetResponse Get(object id)
    {
        var value = _planetService.Get(id);
        var response = _mapper.Map<GetAllPlanetResponse>(value.Data);
        return response;
    }

    public List<GetAllPlanetResponse> GetAll()
    {
        var value = _planetService.GetAll();
        var response = _mapper.Map<List<GetAllPlanetResponse>>(value.Data);
        return response;
    }
}
