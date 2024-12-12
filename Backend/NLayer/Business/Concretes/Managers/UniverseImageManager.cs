using Microsoft.EntityFrameworkCore;
using NLayer.Business.Abstracts;
using NLayer.Core.Exceptions;
using NLayer.Core.Utilities.ImageOperations;
using NLayer.Core.Utilities.Infos;
using NLayer.Core.Utilities.ReturnTypes;
using NLayer.DataAccess.Abstracts;
using NLayer.Entities.Concretes;

namespace NLayer.Business.Concretes.Managers;

public class UniverseImageManager : BaseManagerAsync<UniverseImage, IUniverseImageDal, int>, IUniverseImageService
{
    private readonly IUniverseDal _universeDal;
    private readonly IGetDefaultImages _getDefaultImages;
    private readonly IThemeSettingDal _themeSettingDal;
    public UniverseImageManager(IUniverseImageDal tdal, IUniverseDal universeDal, IGetDefaultImages getDefaultImages, IThemeSettingDal themeSettingDal) : base(tdal)
    {
        _universeDal = universeDal;
        _getDefaultImages = getDefaultImages;
        _themeSettingDal = themeSettingDal;
    }
    public async Task<IDataReturnType<ICollection<UniverseImage>>> PrepareUserForRegister()
    {
        try
        {
            var universeImages = await GetFirstUsersImages();
            if (universeImages == null)
                throw new UserException("Görsel bulunamadı. Lütfen uygulama yöneticisine durumu bildiriniz.");

            return new DataReturnType<ICollection<UniverseImage>>(universeImages, GetDatasInfo.SuccessListData, CrudOperation.List);
        }
        catch (Exception ex)
        {
            return new DataReturnType<ICollection<UniverseImage>>(GetDatasInfo.FailedListData, CrudOperation.List, ex);
        }
    }

    private async Task UpdateDatabaseWithNewImages()
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

    private async Task<ICollection<UniverseImage>> GetFirstUsersImages()
    {
        var universeImages = await _tdal.GetAllAsync(x => x.Universe.Name == "Fantastic Universe", x => x.Include(x => x.Universe));
        return universeImages;
    }

    private async Task AddFirstUniverseData()
    {
        var firstUniverse = await _universeDal.GetAsync(u => u.Name == "Fantastic Universe");
        if (firstUniverse != null)
        {
            return;
        }

        var themeSetting = new ThemeSetting()
        {
            Background = BackgroundType.Default,
            FontColorR = 0.ToString(),
            FontColorB = 0.ToString(),
            FontColorG = 0.ToString(),
            FontFamily = string.Empty,
        };
        await _themeSettingDal.AddAsync(themeSetting);

        var universe = new Universe()
        {
            Name = "Fantastic Universe",
            ThemeSetting = themeSetting,
            ThemeSettingId = themeSetting.Id,
        };
        await _universeDal.AddAsync(universe);
    }
    public async Task<IReturnType> AddRangeAsync(List<UniverseImage> universeImage)
    {
        return await ExecuteSafely(() => _tdal.AddRangeAsync(universeImage), CrudOperation.Add);
    }
}
