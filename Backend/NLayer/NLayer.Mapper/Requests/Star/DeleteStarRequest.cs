using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Star;

public class DeleteStarRequest : IDeleteRequest
{
    public int Id { get; set; }
}
