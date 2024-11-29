using NLayer.Core.Entities.Authentication;
using System.Security.Claims;

namespace NLayer.Core.Security.Jwt;

public interface ITokenService
{
    string GenerateAccessToken(AppUser user, ICollection<string> roles); // Kullanıcı ve roller için erişim tokeni üretir
    string GenerateRefreshToken(); // Yeni bir refresh token oluşturur
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);  // Süresi dolmuş bir token'den kullanıcı bilgilerini alır
}
