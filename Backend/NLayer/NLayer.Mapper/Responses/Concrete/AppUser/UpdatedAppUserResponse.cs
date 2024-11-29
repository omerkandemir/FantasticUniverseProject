using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.AppUser;

public class UpdatedAppUserResponse : IUpdatedResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
