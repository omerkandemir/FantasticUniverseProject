using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.Universe;

public class DeleteUniverseRequest : IDeleteRequest
{
    public int Id { get; set; }
}
