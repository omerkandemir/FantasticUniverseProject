using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.AppUser;

public class ConfirmMailRequest : IUpdateRequest
{
    public int Id { get; set; }
    public int ConfirmCode { get; set; }
}
