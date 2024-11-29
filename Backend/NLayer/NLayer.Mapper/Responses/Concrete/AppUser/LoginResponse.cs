using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.AppUser;

public class LoginResponse : IResponse
{
    public int Id { get; set; }
    public string RedirectTo { get; set; } // Yönlendirme URL'si
    public string UserName { get; set; } // Kullanıcı adı
    public byte[] ImageURL { get; set; } // Resim URL'si
    public bool IsEmailConfirmed { get; set; } // E-posta onayı durumu
    public string Email { get; set; } // Kullanıcı e-postası 
    public bool Success { get; set; }
    public string Message { get; set; }
    public string Token { get; set; }
}
