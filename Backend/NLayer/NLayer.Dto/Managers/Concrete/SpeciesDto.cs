using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Species;
using NLayer.Mapper.Responses.Species;

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
    public IResponse Add(CreateSpeciesRequest request)
    {
        Species species = _mapper.Map<Species>(request);
        var result = _speciesService.Add(species);
        var response = _mapper.Map<CreatedSpeciesResponse>(species);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Species>(response, species);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IResponse Update(UpdateSpeciesRequest request)
    {
        Species species = _mapper.Map<Species>(request);
        var result = _speciesService.Update(species);
        var response = _mapper.Map<UpdatedSpeciesResponse>(species);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Species>(response, species);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IResponse Delete(DeleteSpeciesRequest request)
    {
        Species species = _mapper.Map<Species>(request);
        var result = _speciesService.Delete(species);
        var response = _mapper.Map<DeletedSpeciesResponse>(species);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Species>(response, species);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
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
