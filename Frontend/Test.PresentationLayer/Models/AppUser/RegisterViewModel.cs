using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.AppUser;
using NLayer.Mapper.Responses.Concrete.UniverseImage;

namespace Test.PresentationLayer.Models.AppUser;
public class RegisterViewModel
{
    public CreateAppUserRequest CreateAppUserRequest { get; set; }

    public List<GetUniverseImageResponse> Images { get; set; }
}

