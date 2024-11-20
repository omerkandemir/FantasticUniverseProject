using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.AppUser;

public class DeletedAppUserResponse : IDeletedResponse
{
    public int Id { get; set; }

}
