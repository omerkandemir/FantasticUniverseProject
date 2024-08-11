using Microsoft.AspNetCore.Identity;

namespace NLayer.Business.Abstracts;

public interface ISignInService<TUser> where TUser : class, new()
{
    Task RefreshSignInAsync(TUser user);
    Task<SignInResult> PasswordSignInAsync(string username, string password, bool isPersistent, bool lockoutOnFailure);
    Task SignInAsync(TUser user, bool isPersistent, string? authenticationMethod = null);
    Task SignOutAsync();
}
