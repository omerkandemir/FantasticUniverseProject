using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.AppRole;

public class UpdatedAppRoleResponse : IUpdatedResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
