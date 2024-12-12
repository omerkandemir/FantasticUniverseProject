using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.AppUser;

public class GetAppUserResponse : IGetAppUserResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public int UniverseImageId { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
}
