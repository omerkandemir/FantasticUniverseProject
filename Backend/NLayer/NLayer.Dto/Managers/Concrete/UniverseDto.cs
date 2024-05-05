using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
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
    public ICreatedResponse Add(CreateUniverseRequest request)
    {
        var value = _mapper.Map<Universe>(request);
        _universeService.Add(value);
        var response = _mapper.Map<CreatedUniverseResponse>(value);
        return response;
    }
    public IUpdatedResponse Update(UpdateUniverseRequest request)
    {
        var value = _mapper.Map<Universe>(request);
        _universeService.Update(value);
        var response = _mapper.Map<UpdatedUniverseResponse>(value);
        return response;
    }
    public IDeletedResponse Delete(DeleteUniverseRequest request)
    {
        var value = _mapper.Map<Universe>(request);
        _universeService.Delete(value);
        var response = _mapper.Map<DeletedUniverseResponse>(value);
        return response;
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
