using NLayer.Mapper.Responses.Concrete.UniverseImage;

namespace Test.PresentationLayer.Models.AppUser;

public class ProfileImageResponse
{
    public int SelectedImageId { get; set; }
    public List<GetUniverseImageResponse>? AvailableImages { get; set; }
}
