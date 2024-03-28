using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.TimeLine;

public class DeletedTimeLineResponse : IDeletedResponse
{
    public int Id { get; set; }
}
