using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Universe;

public class DeletedUniverseResponse : IDeletedResponse
{
    public int Id { get; set; }
}
