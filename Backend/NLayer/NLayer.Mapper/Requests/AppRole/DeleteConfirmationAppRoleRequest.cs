using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.AppRole;

public class DeleteConfirmationAppRoleRequest : IDeleteRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
}
