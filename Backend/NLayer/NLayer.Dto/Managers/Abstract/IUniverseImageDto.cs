using NLayer.Core.Dto.Abstracts;
using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.UniverseImage;
using NLayer.Mapper.Responses.UniverseImage;

namespace NLayer.Dto.Managers.Abstract;

public interface IUniverseImageDto : IEntityRepositoryAsyncDto<
    CreateUniverseImageRequest,
    UpdateUniverseImageRequest,
    DeleteUniverseImageRequest,
    GetAllUniverseImageResponse>
{
    Task AddFirstUserDatas();
    Task<ICollection<UniverseImage>> GetFirstUserImages();
}
