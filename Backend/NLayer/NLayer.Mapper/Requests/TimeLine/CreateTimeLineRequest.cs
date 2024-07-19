using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.TimeLine;

public class CreateTimeLineRequest : ICreateRequest
{
    public int StartingAdventureId { get; set; }
}
