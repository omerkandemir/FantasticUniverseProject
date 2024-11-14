using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Star;
using NLayer.Mapper.Responses.Star;

namespace NLayer.Dto.Managers.Concrete;

public class StarDto : IStarDto
{
    private readonly IStarService _starService;
    private readonly IMapper _mapper;
    public StarDto(IStarService starService, IMapper mapper)
    {
        _starService = starService;
        _mapper = mapper;
    }
    public async Task<IResponse> AddAsync(CreateStarRequest request)
    {
        Star star = _mapper.Map<Star>(request);
        var result = await _starService.AddAsync(star);
        var response = _mapper.Map<CreatedStarResponse>(star);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Star>(response, star);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> UpdateAsync(UpdateStarRequest request)
    {
        Star star = _mapper.Map<Star>(request);
        var result = await _starService.UpdateAsync(star);
        var response = _mapper.Map<UpdatedStarResponse>(star);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Star>(response, star);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public async Task<IResponse> DeleteAsync(DeleteStarRequest request)
    {
        Star star = _mapper.Map<Star>(request);
        var result = await _starService.DeleteAsync(star);
        var response = _mapper.Map<DeletedStarResponse>(star);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Star>(response, star);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public async Task<IGetResponse> GetAsync(object id)
    {
        var value = await _starService.GetAsync(id);
        var response = _mapper.Map<GetAllStarResponse>(value.Data);
        return response;
    }

    public async Task<List<GetAllStarResponse>> GetAllAsync()
    {
        var value = await _starService.GetAllAsync();
        var response = _mapper.Map<List<GetAllStarResponse>>(value.Data);
        return response;
    }
}
