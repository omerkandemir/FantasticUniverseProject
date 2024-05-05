using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Species;

public class DeleteSpeciesRequest : IDeleteRequest
{
    public int Id { get; set; }
}
