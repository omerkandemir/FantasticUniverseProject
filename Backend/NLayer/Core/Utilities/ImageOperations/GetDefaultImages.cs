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
        var currentDirectory = Directory.GetCurrentDirectory();
        var projectDirectory = Directory.GetParent(currentDirectory).FullName;
        var imagesDirectory = Path.Combine(projectDirectory, "Backend", "NLayer", "Core", "FirstDatas", "Images").Replace("\\", "/");
        return imagesDirectory;
    }
}
