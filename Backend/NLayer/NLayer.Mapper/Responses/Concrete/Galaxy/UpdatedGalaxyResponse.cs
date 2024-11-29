using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.Galaxy;

public class UpdatedGalaxyResponse : IUpdatedResponse
{
    public int Id { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int UniverseId { get; set; }
    public string Name { get; set; }
}
