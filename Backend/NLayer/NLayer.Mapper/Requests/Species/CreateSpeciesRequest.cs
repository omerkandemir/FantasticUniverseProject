using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Species;

public class CreateSpeciesRequest : ICreateRequest
{
    public string Name { get; set; }
}
