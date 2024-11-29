using Microsoft.AspNetCore.Identity;

namespace NLayer.Core.Authentication.Abstracts;

public interface ISignInService<TUser> where TUser : class, new()
{
    Task RefreshSignInAsync(TUser user);
    Task<SignInResult> LoginAsync(string username, string password, bool isPersistent, bool lockoutOnFailure);
    Task SignInAsync(TUser user, bool isPersistent, string? authenticationMethod = null);
    Task SignOutAsync();
}
