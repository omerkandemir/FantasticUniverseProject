using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
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
    public ICreatedResponse Add(CreatePlanetRequest request)
    {
        var value = _mapper.Map<Planet>(request);
        _planetService.Add(value);
        var response = _mapper.Map<CreatedPlanetResponse>(value);
        return response;
    }
    public IUpdatedResponse Update(UpdatePlanetRequest request)
    {
        var value = _mapper.Map<Planet>(request);
        _planetService.Update(value);
        var response = _mapper.Map<UpdatedPlanetResponse>(value);
        return response;
    }
    public IDeletedResponse Delete(DeletePlanetRequest request)
    {
        var value = _mapper.Map<Planet>(request);
        _planetService.Delete(value);
        var response = _mapper.Map<DeletedPlanetResponse>(value);
        return response;
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
