using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Star;

public class DeletedStarResponse : IDeletedResponse
{
    public int Id { get; set; }
}
