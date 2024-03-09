using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.TimeLine;

public class DeleteTimeLineRequest : IDeleteRequest
{
    public int Id { get; set; }
}
