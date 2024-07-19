using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.AppUser;

public class UpdateAppUserInfoRequest : IUpdateRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    
}
