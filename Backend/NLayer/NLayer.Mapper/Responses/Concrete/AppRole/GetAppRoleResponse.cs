using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.AppRole;

public class GetAppRoleResponse : IGetAppRoleResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
}
