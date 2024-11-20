using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.Universe;

public class DeletedUniverseResponse : IDeletedResponse
{
    public int Id { get; set; }
}
