using NLayer.Mapper.Responses.Concrete.UniverseImage;

namespace Test.PresentationLayer.Models.AppUser;

public class ChangeProfileImageViewModel
{
    public List<GetUniverseImageResponse>? GetAllUniverseImageResponses { get; set; }
    public int SelectedImageId { get; set; }
    public string? CurrentImageBase64 { get; set; }
}
