using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.Species;

public class CreatedSpeciesResponse : ICreatedResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; }
}
