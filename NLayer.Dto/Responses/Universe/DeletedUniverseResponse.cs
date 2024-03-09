using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.Universe;

public class DeletedUniverseResponse : IDeletedResponse
{
    public int Id { get; set; }
}
