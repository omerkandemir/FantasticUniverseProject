using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Species;

public class DeletedSpeciesResponse : IDeletedResponse
{
    public int Id { get; set; }
}
