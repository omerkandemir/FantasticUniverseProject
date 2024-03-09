using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.Star;

public class DeleteStarRequest : IDeleteRequest
{
    public int Id { get; set; }
}
