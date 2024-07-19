using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Union;
using NLayer.Mapper.Responses.Union;

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
    public IErrorResponse Add(CreateUnionRequest request)
    {
        var value = _mapper.Map<Union>(request);
        var result = _unionService.Add(value);
        var response = _mapper.Map<CreatedUnionResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IErrorResponse Update(UpdateUnionRequest request)
    {
        var value = _mapper.Map<Union>(request);
        var result = _unionService.Update(value);
        var response = _mapper.Map<UpdatedUnionResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IErrorResponse Delete(DeleteUnionRequest request)
    {
        var value = _mapper.Map<Union>(request);
        var result = _unionService.Delete(value);
        var response = _mapper.Map<DeletedUnionResponse>(value);
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
