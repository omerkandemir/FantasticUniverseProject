using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Species;

public class UpdatedSpeciesResponse : IUpdatedResponse
{
    public int Id { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string Name { get; set; }
}
