using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.AppRole;

public class DeleteAppRoleRequest : IDeleteRequest
{
    public int Id { get; set; }
}
