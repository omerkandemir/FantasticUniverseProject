using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.AppUser;

public class UpdateAppUserPasswordRequest : IUpdateRequest
{
    public int Id { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmNewPassword { get; set; }
}
