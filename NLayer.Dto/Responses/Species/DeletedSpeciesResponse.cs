using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.Species;

public class DeletedSpeciesResponse : IDeletedResponse
{
    public int Id { get; set; }
}
