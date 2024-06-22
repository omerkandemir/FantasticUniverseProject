using NLayer.Core.Business.Abstract;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Abstracts;

public interface IUniverseImageService : IEntityServiceRepository<UniverseImage>
{
    void UpdateDatabaseWithNewImages();
    List<UniverseImage> GetFirstImagesFromDatabase();
}
