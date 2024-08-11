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
    public IResponse Add(CreateUnionRequest request)
    {
        Union union = _mapper.Map<Union>(request);
        var result = _unionService.Add(union);
        var response = _mapper.Map<CreatedUnionResponse>(union);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Union>(response, union);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IResponse Update(UpdateUnionRequest request)
    {
        Union union = _mapper.Map<Union>(request);
        var result = _unionService.Update(union);
        var response = _mapper.Map<UpdatedUnionResponse>(union);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Union>(response, union);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IResponse Delete(DeleteUnionRequest request)
    {
        Union union = _mapper.Map<Union>(request);
        var result = _unionService.Delete(union);
        var response = _mapper.Map<DeletedUnionResponse>(union);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<Union>(response, union);
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
