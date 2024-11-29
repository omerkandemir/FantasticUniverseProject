using Microsoft.AspNetCore.Identity;
using NLayer.Core.Authentication.Abstracts;
using NLayer.Core.Authentication.Concrete.IdentityUser;
using NLayer.Core.Entities.Authentication;

namespace NLayer.Core.Authentication.Concrete;

public class UserManagerAdapter : UserManagerIdentityUser<AppUser>, IUserService<AppUser>
{
    public UserManagerAdapter(UserManager<AppUser> userManager) : base(userManager)
    {
    }
}
