using NLayer.Core.Dto.Abstracts;
using NLayer.Entities.Concretes;
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
    Task<ICollection<UniverseImage>> PrepareUserForRegister();
}
