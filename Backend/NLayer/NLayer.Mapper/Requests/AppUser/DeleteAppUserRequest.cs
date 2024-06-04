using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.AppUser;

public class DeleteAppUserRequest : IDeleteRequest
{
    public int Id { get; set; }
}
