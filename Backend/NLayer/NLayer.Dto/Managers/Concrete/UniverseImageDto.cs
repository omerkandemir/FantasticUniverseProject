using AutoMapper;
using NLayer.Business.Abstracts;
using NLayer.Core.Dto.Abstracts;
using NLayer.Core.Dto.ReturnTypes;
using NLayer.Dto.Managers.Abstract;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.UniverseImage;
using NLayer.Mapper.Responses.UniverseImage;

namespace NLayer.Dto.Managers.Concrete;

public class UniverseImageDto : IUniverseImageDto
{
    private readonly IUniverseImageService _universeImageService;
    private readonly IMapper _mapper;
    private readonly IUniverseService _universeService;
    public UniverseImageDto(IUniverseImageService universeImageService, IMapper mapper, IUniverseService universeService)
    {
        _universeImageService = universeImageService;
        _mapper = mapper;
        _universeService = universeService;
    }
    public void AddFirstUserDatas()
    {
        _universeService.AddFirstUniverseData();
        _universeImageService.UpdateDatabaseWithNewImages();
    }
    public List<UniverseImage> GetFirstUserImages()
    {
        return _universeImageService.GetFirstImagesFromDatabase();
    }
    public IErrorResponse Add(CreateUniverseImageRequest request)
    {
        var value = _mapper.Map<UniverseImage>(request);
        var result = _universeImageService.Add(value);
        var response = _mapper.Map<CreatedUniverseImageResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public IErrorResponse Update(UpdateUniverseImageRequest request)
    {
        var value = _mapper.Map<UniverseImage>(request);
        var result = _universeImageService.Update(value);
        var response = _mapper.Map<UpdatedUniverseImageResponse>(value);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse(response);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public IErrorResponse Delete(DeleteUniverseImageRequest request)
    {
        var value = _mapper.Map<UniverseImage>(request);
        var result = _universeImageService.Delete(value);
        var response = _mapper.Map<DeletedUniverseImageResponse>(value);
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
        var value = _universeImageService.Get(id);
        var response = _mapper.Map<GetAllUniverseImageResponse>(value.Data);
        return response;
    }

    public List<GetAllUniverseImageResponse> GetAll()
    {
        var value = _universeImageService.GetAll();
        var response = _mapper.Map<List<GetAllUniverseImageResponse>>(value.Data);
        return response;
    }
}
