using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.AppUser;

public class LoginRequest : IRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
