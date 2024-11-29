namespace NLayer.Core.Utilities.ImageOperations;

public class GetDefaultImages : IGetDefaultImages
{
    public string[] GetImageFiles()
    {
        if (Directory.Exists(GetFolderPath()))
        {
            return Directory.GetFiles(GetFolderPath(), "*.*", SearchOption.TopDirectoryOnly)
                            .Where(f => f.EndsWith(".jpg") || f.EndsWith(".png") || f.EndsWith(".jpeg"))
                            .ToArray();
        }
        return Array.Empty<string>();
    }
    private string GetFolderPath()
    {
        // Projenin ana dizinini al
        var projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName; 
        // Gerekli alt dizinleri ekle
        var imagesDirectory = Path.Combine(projectDirectory, "Backend", "NLayer", "Core", "FirstDatas", "Images");
        return imagesDirectory; // Tam yolu döndür
    }
}
