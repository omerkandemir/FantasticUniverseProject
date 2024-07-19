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
    public IErrorResponse Add(CreateStarRequest request)
    {
        var value = _mapper.Map<Star>(request);
        var result = _starService.Add(value);
        var response = _mapper.Map<CreatedStarResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IErrorResponse Update(UpdateStarRequest request)
    {
        var value = _mapper.Map<Star>(request);
        var result = _starService.Update(value);
        var response = _mapper.Map<UpdatedStarResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IErrorResponse Delete(DeleteStarRequest request)
    {
        var value = _mapper.Map<Star>(request);
        var result = _starService.Delete(value);
        var response = _mapper.Map<DeletedStarResponse>(value);
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
        var value = _starService.Get(id);
        var response = _mapper.Map<GetAllStarResponse>(value.Data);
        return response;
    }

    public List<GetAllStarResponse> GetAll()
    {
        var value = _starService.GetAll();
        var response = _mapper.Map<List<GetAllStarResponse>>(value.Data);
        return response;
    }
}
