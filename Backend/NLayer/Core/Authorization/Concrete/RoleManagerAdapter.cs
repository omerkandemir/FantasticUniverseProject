using Microsoft.AspNetCore.Identity;
using NLayer.Core.Authorization.Abstract;
using NLayer.Core.Authorization.Concrete.IdentityUser;
using NLayer.Core.Entities.Authorization;

namespace NLayer.Core.Authorization.Concrete;

public class RoleManagerAdapter : RoleManagerIdentityUser<AppRole>, IRoleService<AppRole>
{
    public RoleManagerAdapter(RoleManager<AppRole> roleManager) : base(roleManager)
    {
    }
}
