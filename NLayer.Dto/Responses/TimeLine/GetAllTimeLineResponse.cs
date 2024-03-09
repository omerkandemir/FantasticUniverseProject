using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.TimeLine;

public class GetAllTimeLineResponse : IGetAllResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int StartingAdventureId { get; set; }
}
