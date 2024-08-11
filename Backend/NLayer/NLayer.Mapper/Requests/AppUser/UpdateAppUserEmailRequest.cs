using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.AppUser;

public class UpdateAppUserEmailRequest : IUpdateRequest
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}
