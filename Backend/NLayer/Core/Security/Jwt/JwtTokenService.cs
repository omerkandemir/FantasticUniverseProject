using Microsoft.IdentityModel.Tokens;
using NLayer.Core.Entities.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace NLayer.Core.Security.Jwt;

public class JwtTokenService : ITokenService
{
    private readonly JwtSettings _jwtSettings;
    public JwtTokenService(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }
    public string GenerateAccessToken(AppUser user, ICollection<string> roles)
    {
        roles ??= new List<string>();

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName), // Kullanıcı adı
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Benzersiz token ID
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()) // Kullanıcı ID
        };

        // Kullanıcının rollerini token'e ekle
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var keyBytes = Encoding.UTF8.GetBytes(_jwtSettings.Secret);
        if (keyBytes.Length * 8 < 256)
        {
            throw new InvalidOperationException("JwtSettings.Secret değeri en az 32 karakter uzunluğunda olmalıdır.");
        }
        var key = new SymmetricSecurityKey(keyBytes); // Anahtar
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // İmzalama algoritması

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer, // Token'in oluşturucusu
            audience: _jwtSettings.Audience, // Token'in hedef kitlesi
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpiration), // Token'in süresi
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token); // Token'i string olarak döndür
    }

    public string GenerateRefreshToken()
    {
        return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)); // Rastgele bir refresh token üret
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero,
            ValidateLifetime = false  // Süresi dolmuş token'leri de kabul et
        }, out SecurityToken securityToken);

        // Token'in geçerli bir JWT olup olmadığını kontrol et
        if (securityToken is not JwtSecurityToken jwtToken ||
            !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return principal; // Kullanıcı bilgilerini içeren principal nesnesini döndür
    }
}
