using NLayer.Core.Business.Abstract;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Abstracts;

public interface IUniverseImageService : IEntityServiceRepositoryAsync<UniverseImage, int>
{
    Task<IReturnType> AddRangeAsync(List<UniverseImage> universeImage);
    Task<IDataReturnType<ICollection<UniverseImage>>> PrepareUserForRegister();
}
