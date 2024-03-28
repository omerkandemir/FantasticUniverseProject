using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.Star;

public class DeletedStarResponse : IDeletedResponse
{
    public int Id { get; set; }
}
