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
    public IResponse Add(CreateUniverseImageRequest request)
    {
        UniverseImage universeImage = _mapper.Map<UniverseImage>(request);
        var result = _universeImageService.Add(universeImage);
        var response = _mapper.Map<CreatedUniverseImageResponse>(universeImage);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<UniverseImage>(response, universeImage);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public IResponse Update(UpdateUniverseImageRequest request)
    {
        UniverseImage universeImage = _mapper.Map<UniverseImage>(request);
        var result = _universeImageService.Update(universeImage);
        var response = _mapper.Map<UpdatedUniverseImageResponse>(universeImage);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<UniverseImage>(response, universeImage);
        }
        else
        {
            return ResponseFactory.CreateErrorResponse(result);
        }
    }

    public IResponse Delete(DeleteUniverseImageRequest request)
    {
        UniverseImage universeImage = _mapper.Map<UniverseImage>(request);
        var result = _universeImageService.Delete(universeImage);
        var response = _mapper.Map<DeletedUniverseImageResponse>(universeImage);
        if (result.Success)
        {
            return ResponseFactory.CreateSuccessResponse<UniverseImage>(response, universeImage);
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
