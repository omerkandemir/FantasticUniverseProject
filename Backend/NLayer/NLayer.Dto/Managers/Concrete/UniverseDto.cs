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
    public IErrorResponse Add(CreateUniverseRequest request)
    {
        var value = _mapper.Map<Universe>(request);
        var result = _universeService.Add(value);
        var response = _mapper.Map<CreatedUniverseResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IErrorResponse Update(UpdateUniverseRequest request)
    {
        var value = _mapper.Map<Universe>(request);
        var result = _universeService.Update(value);
        var response = _mapper.Map<UpdatedUniverseResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IErrorResponse Delete(DeleteUniverseRequest request)
    {
        var value = _mapper.Map<Universe>(request);
        var result = _universeService.Delete(value);
        var response = _mapper.Map<DeletedUniverseResponse>(value);
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
