using Microsoft.EntityFrameworkCore;
using NLayer.Business.Abstracts;
using NLayer.Core.Utilities.ImageOperations;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class UniverseImageManager : BaseManager<UniverseImage, IUniverseImageDal>, IUniverseImageService
{
    private readonly IUniverseDal _universeDal;
    private readonly IGetDefaultImages _getDefaultImages;
    public UniverseImageManager(IUniverseImageDal tdal, IUniverseDal universeDal, IGetDefaultImages getDefaultImages) : base(tdal)
    {
        _universeDal = universeDal;
        _getDefaultImages = getDefaultImages;
    }

    public void UpdateDatabaseWithNewImages()
    {
        string universeName = "Fantastic Universe";
        var universe = _universeDal.Get(x => x.Name == universeName);

        // Eğer evren bulunamazsa işlem yapma
        if (universe == null)
        {
            return;
        }

        // Veritabanındaki mevcut görsellerin byte[] verilerini al
        var existingImages = _tdal.GetAll(ui => ui.UniverseId == universe.Id)
                              .Select(ui => ui.ImageURL) 
                              .ToHashSet();

        // Program üzerindeki tüm görselleri al
        var imageFiles = _getDefaultImages.GetImageFiles();
        var newImages = new List<UniverseImage>();

        foreach (var file in imageFiles)
        {
            var imageBytes = File.ReadAllBytes(file);

            // Eğer görsel zaten veritabanında varsa, eklemiyoruz
            bool imageExists = false;
            foreach (var existingImage in existingImages)
            {
                if (imageBytes.SequenceEqual(existingImage))
                {
                    imageExists = true;
                    break;
                }
            }

            if (imageExists)
            {
                continue;
            }

            var universeImage = new UniverseImage
            {
                UniverseId = universe.Id,
                ImageURL = imageBytes,
            };
            newImages.Add(universeImage);
        }
        // Yeni görselleri veritabanına ekle
        foreach (var universeImage in newImages)
        {
            _tdal.Add(universeImage);
        }
}

    public List<UniverseImage> GetFirstImagesFromDatabase()
    {
        return _tdal.GetAll(x => x.Universe.Name == "Fantastic Universe", x => x.Include(x => x.Universe));
    }
}
