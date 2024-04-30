using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Dto.Managers.Abstract;
using NLayer.Dto.Requests.Species;
using NLayer.Dto.Responses.Species;
using NLayer.Entities.Concretes;

namespace NLayer.Dto.Managers.Concrete;

public class SpeciesDto : ISpeciesDto
{
    private readonly ISpeciesService _speciesService;
    private readonly IMapper _mapper;
    public SpeciesDto(ISpeciesService speciesService, IMapper mapper)
    {
        _speciesService = speciesService;
        _mapper = mapper;
    }
    public ICreatedResponse Add(CreateSpeciesRequest request)
    {
        var value = _mapper.Map<Species>(request);
        _speciesService.Add(value);
        var response = _mapper.Map<CreatedSpeciesResponse>(value);
        return response;
    }
    public IUpdatedResponse Update(UpdateSpeciesRequest request)
    {
        var value = _mapper.Map<Species>(request);
        _speciesService.Update(value);
        var response = _mapper.Map<UpdatedSpeciesResponse>(value);
        return response;
    }
    public IDeletedResponse Delete(DeleteSpeciesRequest request)
    {
        var value = _mapper.Map<Species>(request);
        _speciesService.Delete(value);
        var response = _mapper.Map<DeletedSpeciesResponse>(value);
        return response;
    }

    public IGetResponse Get(object id)
    {
        var value = _speciesService.Get(id);
        var response = _mapper.Map<GetAllSpeciesResponse>(value.Data);
        return response;
    }

    public List<GetAllSpeciesResponse> GetAll()
    {
        var value = _speciesService.GetAll();
        var response = _mapper.Map<List<GetAllSpeciesResponse>>(value.Data);
        return response;
    }
}
