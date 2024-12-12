using NLayer.Core.Authorization.Abstract;
using NLayer.Core.Authorization.Concrete.IdentityUser;

namespace NLayer.Core.Authorization.Concrete;

public class AuthorizationManagerAdapter : AuthorizationManagerIdentityUser, IAuthorizationService
{
    public AuthorizationManagerAdapter(Microsoft.AspNetCore.Authorization.IAuthorizationService authorizationService) : base(authorizationService)
    {
    }
}
