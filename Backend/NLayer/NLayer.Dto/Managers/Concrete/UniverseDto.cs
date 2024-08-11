using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Universe;
using NLayer.Mapper.Responses.Universe;

namespace NLayer.Dto.Managers.Concrete;

public class UniverseDto : IUniverseDto
{
    private readonly IUniverseService _universeService;
    private readonly IMapper _mapper;
    public UniverseDto(IUniverseService universeService, IMapper mapper)
    {
        _universeService = universeService;
        _mapper = mapper;
    }
    public IResponse Add(CreateUniverseRequest request)
    {
        Universe universe = _mapper.Map<Universe>(request);
        var result = _universeService.Add(universe);
        var response = _mapper.Map<CreatedUniverseResponse>(universe);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Universe>(response, universe);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IResponse Update(UpdateUniverseRequest request)
    {
        Universe universe = _mapper.Map<Universe>(request);
        var result = _universeService.Update(universe);
        var response = _mapper.Map<UpdatedUniverseResponse>(universe);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Universe>(response, universe);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IResponse Delete(DeleteUniverseRequest request)
    {
        Universe universe = _mapper.Map<Universe>(request);
        var result = _universeService.Delete(universe);
        var response = _mapper.Map<DeletedUniverseResponse>(universe);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Universe>(response, universe);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public IGetResponse Get(object id)
    {
        var value = _universeService.Get(id);
        var response = _mapper.Map<GetAllUniverseResponse>(value.Data);
        return response;
    }

    public List<GetAllUniverseResponse> GetAll()
    {
        var value = _universeService.GetAll();
        var response = _mapper.Map<List<GetAllUniverseResponse>>(value.Data);
        return response;
    }
}
