using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Union;

public class DeletedUnionResponse : IDeletedResponse
{
    public int Id { get; set; }
}
