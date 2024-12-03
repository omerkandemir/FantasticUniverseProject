namespace NLayer.Core.Helpers;

public static class PathHelper
{

    /// <summary>
    /// Verilen bir başlangıç yolundan itibaren hedef klasörü bulur.
    /// </summary>
    /// <param name="startPath">Başlangıç yolu</param>
    /// <param name="targetFolderName">Hedef klasör adı</param>
    /// <returns>Hedef klasörün tam yolu</returns>
    /// <exception cref="DirectoryNotFoundException">Eğer klasör bulunamazsa fırlatılır.</exception>
    public static string FindParentDirectory(string startPath, string targetFolderName)
    {
        var currentDirectory = new DirectoryInfo(startPath);

        while (currentDirectory != null)
        {
            if (currentDirectory.Name.Equals(targetFolderName, StringComparison.OrdinalIgnoreCase))
            {
                return currentDirectory.FullName;
            }
            currentDirectory = currentDirectory.Parent;
        }

        throw new DirectoryNotFoundException($"The directory '{targetFolderName}' was not found in the path '{startPath}' or its parent directories.");
    }
}
