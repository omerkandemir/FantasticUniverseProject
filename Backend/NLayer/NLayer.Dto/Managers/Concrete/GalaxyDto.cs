using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Dto.Managers.Abstract;
using NLayer.Dto.Requests.Galaxy;
using NLayer.Dto.Responses.Galaxy;
using NLayer.Entities.Concretes;

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
    public ICreatedResponse Add(CreateGalaxyRequest request)
    {
        var value = _mapper.Map<Galaxy>(request);
        _galaxyService.Add(value);
        var response = _mapper.Map<CreatedGalaxyResponse>(value);
        return response;
    }
    public IUpdatedResponse Update(UpdateGalaxyRequest request)
    {
        var value = _mapper.Map<Galaxy>(request);
        _galaxyService.Update(value);
        var response = _mapper.Map<UpdatedGalaxyResponse>(value);
        return response;
    }
    public IDeletedResponse Delete(DeleteGalaxyRequest request)
    {
        var value = _mapper.Map<Galaxy>(request);
        _galaxyService.Delete(value);
        var response = _mapper.Map<DeletedGalaxyResponse>(value);
        return response;
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
