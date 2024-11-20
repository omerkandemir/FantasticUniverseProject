using NLayer.Mapper.Responses.Concrete.UniverseImage;

namespace Test.PresentationLayer.Models.AppUser;

public class ChangeProfileImageViewModel
{
    public GetAllUniverseImageResponse? GetAllUniverseImageResponses { get; set; }
    public int SelectedImageId { get; set; }
}
