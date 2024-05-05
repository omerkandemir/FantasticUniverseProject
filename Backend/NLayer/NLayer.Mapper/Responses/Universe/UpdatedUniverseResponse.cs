using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Universe;

public class UpdatedUniverseResponse : IUpdatedResponse
{
    public int Id { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public string Name { get; set; }
}
