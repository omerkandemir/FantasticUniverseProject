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

    public static string GetSessionId()
    {
        var httpContext = GetHttpContext();
        return httpContext?.Session.GetString("SessionId") ?? string.Empty;
    }
    public static string GetIpAddress()
    {
        var httpContext = GetHttpContext();
        return httpContext?.Items["IpAddress"]?.ToString() ?? "Unknown IP"; 
    }

    public static string GetCorrelationId()
    {
        return _httpContextAccessor?.HttpContext?.TraceIdentifier ?? Guid.NewGuid().ToString();
    }

    public static string GetBrowserInfo()
    {
        return _httpContextAccessor?.HttpContext?.Request?.Headers["User-Agent"].ToString() ?? "Unknown Browser";
    }
}
