using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.Union;

public class DeletedUnionResponse : IDeletedResponse
{
    public int Id { get; set; }
}
