using NLayer.Core.Dto.Abstracts;
using NLayer.Mapper.Requests.UniverseImage;
using NLayer.Mapper.Responses.Abstract;
using NLayer.Mapper.Responses.Concrete.UniverseImage;

namespace NLayer.Dto.Managers.Abstract;

public interface IUniverseImageDto : IEntityRepositoryAsyncDto<
    IGetUniverseImageResponse,
    CreateUniverseImageRequest,
    UpdateUniverseImageRequest,
    DeleteUniverseImageRequest,
    GetUniverseImageResponse,
    GetAllUniverseImageResponse>
{
    Task<IResponse> AddRangeAsync(List<CreateUniverseImageRequest> createRequest);
    Task<List<GetUniverseImageResponse>> PrepareUserForRegister();
}
