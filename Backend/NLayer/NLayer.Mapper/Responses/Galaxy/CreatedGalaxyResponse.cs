using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Galaxy;

public class CreatedGalaxyResponse : ICreatedResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int UniverseId { get; set; }
    public string Name { get; set; }

}
