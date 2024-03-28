using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.Species;

public class UpdateSpeciesRequest : IUpdateRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
}
