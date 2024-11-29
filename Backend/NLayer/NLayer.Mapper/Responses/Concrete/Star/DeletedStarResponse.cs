using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.Star;

public class DeletedStarResponse : IDeletedResponse
{
    public int Id { get; set; }
}
