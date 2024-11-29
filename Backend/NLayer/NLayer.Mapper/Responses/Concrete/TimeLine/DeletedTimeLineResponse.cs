using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.TimeLine;

public class DeletedTimeLineResponse : IDeletedResponse
{
    public int Id { get; set; }
}
