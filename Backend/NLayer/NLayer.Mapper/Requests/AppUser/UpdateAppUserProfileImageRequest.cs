using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.AppUser;

public class UpdateAppUserProfileImageRequest : IUpdateRequest
{
    public int Id { get; set; }
    public int SelectedImageId { get; set; }
}
