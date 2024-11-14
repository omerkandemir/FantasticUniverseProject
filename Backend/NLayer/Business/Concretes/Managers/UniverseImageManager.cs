using Microsoft.EntityFrameworkCore;
using NLayer.Business.Abstracts;
using NLayer.Core.Utilities.ImageOperations;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class UniverseImageManager : BaseManagerAsync<UniverseImage, IUniverseImageDal>, IUniverseImageService
{
    private readonly IUniverseDal _universeDal;
    private readonly IGetDefaultImages _getDefaultImages;
    public UniverseImageManager(IUniverseImageDal tdal, IUniverseDal universeDal, IGetDefaultImages getDefaultImages) : base(tdal)
    {
        _universeDal = universeDal;
        _getDefaultImages = getDefaultImages;
    }

    public async Task UpdateDatabaseWithNewImages()
    {
        string universeName = "Fantastic Universe";
        var universe = await _universeDal.GetAsync(x => x.Name == universeName);

        if (universe == null)
        {
            return;
        }

        var existingImages = (await _tdal.GetAllAsync(ui => ui.UniverseId == universe.Id))
                              .Select(ui => ui.ImageURL)
                              .ToHashSet();

        var imageFiles = _getDefaultImages.GetImageFiles();
        var newImages = new List<UniverseImage>();

        foreach (var file in imageFiles)
        {
            var imageBytes = await File.ReadAllBytesAsync(file);

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
        if (newImages.Any())
        {
            await _tdal.AddRangeAsync(newImages);
        }
    }

    public async Task<ICollection<UniverseImage>> GetFirstImagesFromDatabase()
    {
        var universeImages = await _tdal.GetAllAsync(x => x.Universe.Name == "Fantastic Universe", x => x.Include(x => x.Universe));
        return universeImages;
    }
}
