using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Universe;

public class DeleteUniverseRequest : IDeleteRequest
{
    public int Id { get; set; }
}
