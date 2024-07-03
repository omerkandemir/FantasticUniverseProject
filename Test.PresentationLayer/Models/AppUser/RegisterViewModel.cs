using NLayer.Entities.Concretes;
using NLayer.Mapper.Requests.AppUser;

namespace Test.PresentationLayer.Models.AppUser;
public class RegisterViewModel
{
    public CreateAppUserRequest CreateAppUserRequest { get; set; }

    public List<UniverseImage> Images { get; set; }
}

