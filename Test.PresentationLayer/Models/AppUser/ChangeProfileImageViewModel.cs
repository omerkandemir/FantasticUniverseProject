using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.UniverseImage;
namespace Test.PresentationLayer.Models.AppUser;

public class ChangeProfileImageViewModel
{
    public List<GetAllUniverseImageResponse>? GetAllUniverseImageResponses { get; set; }
    //public UpdateAppUserProfileImageRequest UpdateAppUserProfileImageRequest { get; set; }
    public int SelectedImageId { get; set; }
}
