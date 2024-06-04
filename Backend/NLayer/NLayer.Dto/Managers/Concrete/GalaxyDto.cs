using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Galaxy;
using NLayer.Mapper.Responses.Galaxy;

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
    public IErrorResponse Add(CreateGalaxyRequest request)
    {
        var value = _mapper.Map<Galaxy>(request);
        var result = _galaxyService.Add(value);
        var response = _mapper.Map<CreatedGalaxyResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IErrorResponse Update(UpdateGalaxyRequest request)
    {
        var value = _mapper.Map<Galaxy>(request);
        var result = _galaxyService.Update(value);
        var response = _mapper.Map<UpdatedGalaxyResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IErrorResponse Delete(DeleteGalaxyRequest request)
    {
        var value = _mapper.Map<Galaxy>(request);
        var result = _galaxyService.Delete(value);
        var response = _mapper.Map<DeletedGalaxyResponse>(value);
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
        var value = _galaxyService.Get(id);
        var response = _mapper.Map<GetAllGalaxyResponse>(value.Data);
        return response;
    }

    public List<GetAllGalaxyResponse> GetAll()
    {
        var value = _galaxyService.GetAll();
        var response = _mapper.Map<List<GetAllGalaxyResponse>>(value.Data);
        return response;
    }
}
