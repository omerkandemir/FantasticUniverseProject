using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.AppUser;

public class UpdateAppUserRequest : IUpdateRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string? Email { get; set; }
    public string Username { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public int UniverseImageId { get; set; }
}
