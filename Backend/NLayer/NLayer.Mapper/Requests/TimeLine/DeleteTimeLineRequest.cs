using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.TimeLine;

public class DeleteTimeLineRequest : IDeleteRequest
{
    public int Id { get; set; }
}
