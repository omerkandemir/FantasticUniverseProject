using Microsoft.AspNetCore.Identity;
using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.Authentication.IdentityUser;
using NLayer.Core.Entities.Authentication;

namespace NLayer.Business.Concretes.Authentication;

public class UserManagerAdapter : UserManagerIdentityUser<AppUser>, IUserService<AppUser>
{
    public UserManagerAdapter(UserManager<AppUser> userManager) : base(userManager)
    {
    }
}
