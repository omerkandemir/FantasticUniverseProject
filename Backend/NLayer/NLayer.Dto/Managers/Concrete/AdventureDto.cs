using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.Adventure;
using NLayer.Mapper.Responses.Adventure;

namespace NLayer.Dto.Managers.Concrete;

public class AdventureDto : IAdventureDto
{
    private readonly IAdventureService _adventureService;
    private readonly IMapper _mapper;
    public AdventureDto(IAdventureService adventureService, IMapper mapper)
    {
        _adventureService = adventureService;
        _mapper = mapper;
    }
    public IErrorResponse Add(CreateAdventureRequest request)
    {
        var value = _mapper.Map<Adventure>(request);
        var result = _adventureService.Add(value);
        var response = _mapper.Map<CreatedAdventureResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IErrorResponse Update(UpdateAdventureRequest request)
    {
        var value = _mapper.Map<Adventure>(request);
        var result = _adventureService.Update(value);
        var response = _mapper.Map<UpdatedAdventureResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }
    public IErrorResponse Delete(DeleteAdventureRequest request)
    {
        var value = _mapper.Map<Adventure>(request);
        var result = _adventureService.Delete(value);
        var response = _mapper.Map<DeletedAdventureResponse>(value);
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
        var value = _adventureService.Get(id);
        var response = _mapper.Map<GetAllAdventureResponse>(value.Data);
        return response;
    }

    public List<GetAllAdventureResponse> GetAll()
    {
        var value = _adventureService.GetAll();
        var response = _mapper.Map<List<GetAllAdventureResponse>>(value.Data);
        return response;
    }

    
}
