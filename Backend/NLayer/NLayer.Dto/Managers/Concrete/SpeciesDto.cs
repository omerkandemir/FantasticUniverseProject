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
    public IErrorResponse Add(CreateSpeciesRequest request)
    {
        var value = _mapper.Map<Species>(request);
        var result = _speciesService.Add(value);
        var response = _mapper.Map<CreatedSpeciesResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IErrorResponse Update(UpdateSpeciesRequest request)
    {
        var value = _mapper.Map<Species>(request);
        var result = _speciesService.Update(value);
        var response = _mapper.Map<UpdatedSpeciesResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IErrorResponse Delete(DeleteSpeciesRequest request)
    {
        var value = _mapper.Map<Species>(request);
        var result = _speciesService.Delete(value);
        var response = _mapper.Map<DeletedSpeciesResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
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
