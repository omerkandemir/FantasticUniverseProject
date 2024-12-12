using FluentValidation;
using NLayer.Business.Abstracts;
using NLayer.Business.DependencyResolvers.Ninject;

namespace NLayer.Business.Concretes.CrossCuttingConcerns.ValidationRules.FluentValidation.UniverseImageValidation;

public static class CustomUniverseImageValidator
{
    public static IRuleBuilderOptions<T, byte[]> IsValidImageExtension<T>(this IRuleBuilder<T, byte[]> ruleBuilder, string[] allowedExtensions)
    {
        return ruleBuilder.Must(image =>
        {
            var extension = GetFileExtension(image); // Görselin uzantısını al
            return allowedExtensions.Contains(extension.ToLower());
        }).WithMessage("Geçerli bir dosya uzantısı değil (yalnızca jpg, jpeg, png).");
    }

    public static IRuleBuilderOptions<T, byte[]> IsValidImageSize<T>(this IRuleBuilder<T, byte[]> ruleBuilder, long maxSize)
    {
        return ruleBuilder.Must(image => image.Length <= maxSize)
            .WithMessage($"Görsel boyutu {maxSize / (1024 * 1024)} MB'yi aşamaz.");
    }
    public static IRuleBuilderOptions<T, byte[]> IsUniqueImage<T>(this IRuleBuilder<T, byte[]> ruleBuilder)
    {
        var universeImageService = InstanceFactory.GetInstance<IUniverseImageService>();
        return ruleBuilder.MustAsync(async (image, cancellationToken) =>
        {
            var allImages = await universeImageService.GetAllAsync();
            return !allImages.Data.Any(existingImage => existingImage.ImageURL.SequenceEqual(image));
        }).WithMessage("Bu görsel zaten mevcut.");
    }

    private static string GetFileExtension(byte[] imageBytes)
    {
        if (imageBytes.Length > 4 && imageBytes[0] == 0xFF && imageBytes[1] == 0xD8) return ".jpg";
        if (imageBytes.Length > 8 && imageBytes[0] == 0x89 && imageBytes[1] == 0x50) return ".png";
        return string.Empty;
    }
}
