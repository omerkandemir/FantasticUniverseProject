using Microsoft.AspNetCore.Identity;

namespace NLayer.Core.Entities.Authentication;

public class AppUser : IdentityUser<int>
{
    public string Name { get; set; }
    public int UniverseImageId { get; set; }
    public string Surname { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public int ConfirmCode { get; set; }
}
