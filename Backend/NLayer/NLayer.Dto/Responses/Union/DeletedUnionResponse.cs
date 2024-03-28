using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.Union;

public class DeletedUnionResponse : IDeletedResponse
{
    public int Id { get; set; }
}
