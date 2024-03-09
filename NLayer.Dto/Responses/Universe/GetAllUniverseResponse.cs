using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.Universe;

public class GetAllUniverseResponse : IGetAllResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; }
    public int TimeLineId { get; set; }
}
