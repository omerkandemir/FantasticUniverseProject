using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.Union;

public class GetAllUnionResponse : IGetAllResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Name { get; set; }
    public string Target { get; set; }
    public int? UnionLeaderId { get; set; }
    public int UniverseId { get; set; }
}
