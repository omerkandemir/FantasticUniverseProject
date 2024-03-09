using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.Union;

public class DeleteUnionRequest : IDeleteRequest
{
    public int Id { get; set; }
}
