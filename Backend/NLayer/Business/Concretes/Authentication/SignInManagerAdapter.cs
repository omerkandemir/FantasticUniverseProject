using Microsoft.AspNetCore.Identity;
using NLayer.Business.Abstracts;
using NLayer.Business.Concretes.Authentication.IdentityUser;
using NLayer.Core.Entities.Authentication;

namespace NLayer.Business.Concretes.Authentication;

public class SignInManagerAdapter : SignInManagerIdentityUser, ISignInService<AppUser>
{
    public SignInManagerAdapter(SignInManager<AppUser> signInManager) : base(signInManager)
    {
    }
}
