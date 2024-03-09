using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.Species;

public class DeleteSpeciesRequest : IDeleteRequest
{
    public int Id { get; set; }
}
