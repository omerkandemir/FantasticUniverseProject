using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.AppUser;

internal class DeletedAppUserResponse : IDeletedResponse
{
    public int Id { get; set; }

}
