using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Union;

public class DeleteUnionRequest : IDeleteRequest
{
    public int Id { get; set; }
}
