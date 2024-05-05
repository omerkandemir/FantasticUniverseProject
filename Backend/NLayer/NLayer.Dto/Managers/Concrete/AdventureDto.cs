using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
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
    public ICreatedResponse Add(CreateAdventureRequest request)
    {
        var value = _mapper.Map<Adventure>(request);
        _adventureService.Add(value);
        var response = _mapper.Map<CreatedAdventureResponse>(value);
        return response;
    }
    public IUpdatedResponse Update(UpdateAdventureRequest request)
    {
        var value = _mapper.Map<Adventure>(request);
        _adventureService.Update(value);
        var response = _mapper.Map<UpdatedAdventureResponse>(value);
        return response;
    }
    public IDeletedResponse Delete(DeleteAdventureRequest request)
    {
        var value = _mapper.Map<Adventure>(request);
        _adventureService.Delete(value);
        var response = _mapper.Map<DeletedAdventureResponse>(value);
        return response;
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
