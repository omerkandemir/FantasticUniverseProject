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
    public async Task AddFirstUserDatas()
    {
        await _universeService.AddFirstUniverseData();
        await _universeImageService.UpdateDatabaseWithNewImages();
    }
    public async Task<ICollection<UniverseImage>> GetFirstUserImages()
    {
        return await _universeImageService.GetFirstImagesFromDatabase();
    }
    public async Task<IResponse> AddAsync(CreateUniverseImageRequest request)
    {
        UniverseImage universeImage = _mapper.Map<UniverseImage>(request);
        var result = await _universeImageService.AddAsync(universeImage);
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

    public async Task<IResponse> UpdateAsync(UpdateUniverseImageRequest request)
    {
        UniverseImage universeImage = _mapper.Map<UniverseImage>(request);
        var result = await _universeImageService.UpdateAsync(universeImage);
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

    public async Task<IResponse> DeleteAsync(DeleteUniverseImageRequest request)
    {
        UniverseImage universeImage = _mapper.Map<UniverseImage>(request);
        var result = await _universeImageService.DeleteAsync(universeImage);
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

    public async Task<IGetResponse> GetAsync(object id)
    {
        var value = await _universeImageService.GetAsync(id);
        var response = _mapper.Map<GetAllUniverseImageResponse>(value.Data);
        return response;
    }

    public async Task<List<GetAllUniverseImageResponse>> GetAllAsync()
    {
        var value = await _universeImageService.GetAllAsync();
        var response = _mapper.Map<List<GetAllUniverseImageResponse>>(value.Data);
        return response;
    }
}
