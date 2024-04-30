using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Dto.Managers.Abstract;
using NLayer.Dto.Requests.Union;
using NLayer.Dto.Responses.Union;
using NLayer.Entities.Concretes;

namespace NLayer.Dto.Managers.Concrete;

public class UnionDto : IUnionDto
{
    private readonly IUnionService _unionService;
    private readonly IMapper _mapper;
    public UnionDto(IUnionService unionService, IMapper mapper)
    {
        _unionService = unionService;
        _mapper = mapper;
    }
    public ICreatedResponse Add(CreateUnionRequest request)
    {
        var value = _mapper.Map<Union>(request);
        _unionService.Add(value);
        var response = _mapper.Map<CreatedUnionResponse>(value);
        return response;
    }
    public IUpdatedResponse Update(UpdateUnionRequest request)
    {
        var value = _mapper.Map<Union>(request);
        _unionService.Update(value);
        var response = _mapper.Map<UpdatedUnionResponse>(value);
        return response;
    }
    public IDeletedResponse Delete(DeleteUnionRequest request)
    {
        var value = _mapper.Map<Union>(request);
        _unionService.Delete(value);
        var response = _mapper.Map<DeletedUnionResponse>(value);
        return response;
    }

    public IGetResponse Get(object id)
    {
        var value = _unionService.Get(id);
        var response = _mapper.Map<GetAllUnionResponse>(value.Data);
        return response;
    }

    public List<GetAllUnionResponse> GetAll()
    {
        var value = _unionService.GetAll();
        var response = _mapper.Map<List<GetAllUnionResponse>>(value.Data);
        return response;
    }
}
