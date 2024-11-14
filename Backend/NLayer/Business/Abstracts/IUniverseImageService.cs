using NLayer.Core.Business.Abstract;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Abstracts;

public interface IUniverseImageService : IEntityServiceRepositoryAsync<UniverseImage>
{
    Task UpdateDatabaseWithNewImages();
    Task<ICollection<UniverseImage>> GetFirstImagesFromDatabase();
}
