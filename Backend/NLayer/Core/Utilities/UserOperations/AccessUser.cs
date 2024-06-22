using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace NLayer.Core.Utilities.UserOperations;

public static class AccessUser
{
    private static IHttpContextAccessor _httpContextAccessor;

    public static void Configure(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    private static HttpContext GetHttpContext()
    {
        return _httpContextAccessor?.HttpContext;
    }
    public static int GetUserId()
    {
        var httpContext = GetHttpContext();
        var userIdClaim = httpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);
        return userIdClaim != null ? Convert.ToInt32(userIdClaim.Value) : 0;
    }
}
