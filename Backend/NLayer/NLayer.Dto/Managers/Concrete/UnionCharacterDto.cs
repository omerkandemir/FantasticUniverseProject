using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.UnionCharacter;
using NLayer.Mapper.Responses.UnionCharacter;

namespace NLayer.Dto.Managers.Concrete;

public class UnionCharacterDto : IUnionCharacterDto
{
    private readonly IUnionCharacterService _unionCharacterService;
    private readonly IMapper _mapper;
    public UnionCharacterDto(IUnionCharacterService unionCharacterService, IMapper mapper)
    {
        _unionCharacterService = unionCharacterService;
        _mapper = mapper;
    }
    public IErrorResponse Add(CreateUnionCharacterRequest request)
    {
        var value = _mapper.Map<UnionCharacter>(request);
        var result = _unionCharacterService.Add(value);
        var response = _mapper.Map<CreatedUnionCharacterResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IErrorResponse Update(UpdateUnionCharacterRequest request)
    {
        var value = _mapper.Map<UnionCharacter>(request);
        var result = _unionCharacterService.Update(value);
        var response = _mapper.Map<UpdatedUnionCharacterResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IErrorResponse Delete(DeleteUnionCharacterRequest request)
    {
        var value = _mapper.Map<UnionCharacter>(request);
        var result = _unionCharacterService.Delete(value);
        var response = _mapper.Map<DeletedUnionCharacterResponse>(value);
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
        var value = _unionCharacterService.Get(id);
        var response = _mapper.Map<GetAllUnionCharacterResponse>(value.Data);
        return response;
    }

    public List<GetAllUnionCharacterResponse> GetAll()
    {
        var value = _unionCharacterService.GetAll();
        var response = _mapper.Map<List<GetAllUnionCharacterResponse>>(value.Data);
        return response;
    }
}
