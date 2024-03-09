using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.Species;

public class CreateSpeciesRequest : ICreateRequest
{
    public string Name { get; set; }
}
