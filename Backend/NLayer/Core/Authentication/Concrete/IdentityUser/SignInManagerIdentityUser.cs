using Microsoft.AspNetCore.Identity;
using NLayer.Core.Entities.Authentication;

namespace NLayer.Core.Authentication.Concrete.IdentityUser;

public abstract class SignInManagerIdentityUser
{
    private readonly SignInManager<AppUser> _signInManager;
    protected SignInManagerIdentityUser(SignInManager<AppUser> signInManager)
    {
        _signInManager = signInManager;
    }
    public Task RefreshSignInAsync(AppUser user)
    {
        return RefreshUser(user);
    }
    public Task SignInAsync(AppUser user, bool isPersistent, string? authenticationMethod = null)
    {
        return _signInManager.SignInAsync(user, isPersistent, authenticationMethod);
    }
    public Task SignOutAsync()
    {
        return _signInManager.SignOutAsync();
    }
    public Task<SignInResult> LoginAsync(string username, string password, bool isPersistent, bool lockoutOnFailure)
    {
        return _signInManager.PasswordSignInAsync(username, password, isPersistent, lockoutOnFailure);
    }
    private Task RefreshUser(AppUser user)
    {
        if (user.SecurityStamp != null)
        {
            return _signInManager.RefreshSignInAsync(user);
        }
        else
        {
            var existUser = _signInManager.UserManager.Users.FirstOrDefault();
            return _signInManager.RefreshSignInAsync(existUser);
        }
    }
}

