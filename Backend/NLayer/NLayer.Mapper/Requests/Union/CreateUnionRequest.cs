using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Union;

public class CreateUnionRequest : ICreateRequest
{
    public string Name { get; set; }
    public string Target { get; set; }
    public int? UnionLeaderId { get; set; }
    public int UniverseId { get; set; }

}
