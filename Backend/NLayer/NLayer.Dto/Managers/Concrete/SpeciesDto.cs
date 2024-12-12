using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Species;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.Species;

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
    public async Task<IResponse> AddAsync(CreateSpeciesRequest request)
    {
        Species species = _mapper.Map<Species>(request);
        var result = await _speciesService.AddAsync(species);
        var response = _mapper.Map<CreatedSpeciesResponse>(species);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Species>(species, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> UpdateAsync(UpdateSpeciesRequest request)
    {
        Species species = _mapper.Map<Species>(request);
        var result = await _speciesService.UpdateAsync(species);
        var response = _mapper.Map<UpdatedSpeciesResponse>(species);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Species>(species, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> DeleteAsync(DeleteSpeciesRequest request)
    {
        Species species = _mapper.Map<Species>(request);
        var result = await _speciesService.DeleteAsync(species);
        var response = _mapper.Map<DeletedSpeciesResponse>(species);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Species>(species, response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public async Task<IGetSpeciesResponse> GetAsync(object id)
    {
        var value = await _speciesService.GetAsync((int)id);
        var response = _mapper.Map<GetSpeciesResponse>(value.Data);
        return response;
    }

    public async Task<IGetAllResponse<IGetSpeciesResponse>> GetAllAsync()
    {
        var value = await _speciesService.GetAllAsync();
        var response = _mapper.Map<GetAllSpeciesResponse>(value.Data);
        return response;
    }
}
