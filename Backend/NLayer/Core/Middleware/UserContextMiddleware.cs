using Microsoft.AspNetCore.Http;
using Serilog.Context;
using System.Security.Claims;

namespace NLayer.Core.Middleware;

public class UserContextMiddleware
{
    private readonly RequestDelegate _next;

    public UserContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Eğer TraceIdentifier yoksa oluşturuluyor
        if (string.IsNullOrEmpty(context.TraceIdentifier))
        {
            context.TraceIdentifier = Guid.NewGuid().ToString();
        }

        string userId = "Anonymous";
        // Eğer SessionId yoksa, yeni bir tane oluştur ve session'a ekle
        if (!context.Session.Keys.Contains("SessionId"))
        {
            context.Session.SetString("SessionId", Guid.NewGuid().ToString());
        }

        var sessionId = context.Session.GetString("SessionId");
        var ipAddress = context.Connection.RemoteIpAddress?.ToString() ?? "Unknown IP";
        var correlationId = context.TraceIdentifier;
        var browserInfo = context.Request.Headers["User-Agent"].ToString();

        if (context.User.Identity.IsAuthenticated)
        {
            userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(userId))
            {
                context.Items["UserId"] = userId;
                context.Items["SessionId"] = sessionId;
                context.Items["IpAddress"] = ipAddress;
                context.Items["CorrelationId"] = correlationId;
                context.Items["BrowserInfo"] = browserInfo;
            }
        }

        using (LogContext.PushProperty("SessionId", sessionId))
        using (LogContext.PushProperty("IpAddress", ipAddress))
        using (LogContext.PushProperty("UserId", userId))
        using (LogContext.PushProperty("CorrelationId", correlationId))
        using (LogContext.PushProperty("BrowserInfo", browserInfo))
        {
            await _next(context);
        }
    }
}
