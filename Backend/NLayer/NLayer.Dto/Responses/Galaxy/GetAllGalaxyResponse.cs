using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.Galaxy;

public class GetAllGalaxyResponse : IGetResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int UniverseId { get; set; }
    public string Name { get; set; }
}
