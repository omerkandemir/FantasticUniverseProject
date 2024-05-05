using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Universe;

public class CreatedUniverseResponse : ICreatedResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; }
}
