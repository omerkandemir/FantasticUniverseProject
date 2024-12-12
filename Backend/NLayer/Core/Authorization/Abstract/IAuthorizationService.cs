using System.Security.Claims;

namespace NLayer.Core.Authorization.Abstract;

public interface IAuthorizationService
{
    Task<bool> AuthorizeAsync(ClaimsPrincipal user, string policyName);
    Task<bool> AuthorizeAsync(ClaimsPrincipal user, object resource, string policyName);
}
