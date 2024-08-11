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
    public IResponse Add(CreateGalaxyRequest request)
    {
        Galaxy galaxy = _mapper.Map<Galaxy>(request);
        var result = _galaxyService.Add(galaxy);
        var response = _mapper.Map<CreatedGalaxyResponse>(galaxy);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Galaxy>(response, galaxy);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IResponse Update(UpdateGalaxyRequest request)
    {
        Galaxy galaxy = _mapper.Map<Galaxy>(request);
        var result = _galaxyService.Update(galaxy);
        var response = _mapper.Map<UpdatedGalaxyResponse>(galaxy);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Galaxy>(response, galaxy);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IResponse Delete(DeleteGalaxyRequest request)
    {
        Galaxy galaxy = _mapper.Map<Galaxy>(request);
        var result = _galaxyService.Delete(galaxy);
        var response = _mapper.Map<DeletedGalaxyResponse>(galaxy);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Galaxy>(response, galaxy);
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
