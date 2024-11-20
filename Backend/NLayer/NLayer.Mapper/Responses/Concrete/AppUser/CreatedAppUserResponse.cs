using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.AppUser;

public class CreatedAppUserResponse : ICreatedResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
}
