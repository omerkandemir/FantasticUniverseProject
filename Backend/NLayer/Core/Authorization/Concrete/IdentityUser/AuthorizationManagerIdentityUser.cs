using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace NLayer.Core.Authorization.Concrete.IdentityUser;

public abstract class AuthorizationManagerIdentityUser
{
    private readonly IAuthorizationService _authorizationService;

    protected AuthorizationManagerIdentityUser(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }
    public Task<bool> AuthorizeAsync(ClaimsPrincipal user, string policyName)
    {
        return Task.FromResult(_authorizationService.AuthorizeAsync(user, policyName).Result.Succeeded);
    }

    public Task<bool> AuthorizeAsync(ClaimsPrincipal user, object resource, string policyName)
    {
        return Task.FromResult(_authorizationService.AuthorizeAsync(user, resource, policyName).Result.Succeeded);
    }
}
