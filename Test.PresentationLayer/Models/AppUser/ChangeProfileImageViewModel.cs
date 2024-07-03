using NLayer.Mapper.Responses.UniverseImage;
namespace Test.PresentationLayer.Models.AppUser;

public class ChangeProfileImageViewModel
{
    public List<GetAllUniverseImageResponse>? getAllUniverseImageResponses { get; set; }
    public int SelectedImageId { get; set; }
}
