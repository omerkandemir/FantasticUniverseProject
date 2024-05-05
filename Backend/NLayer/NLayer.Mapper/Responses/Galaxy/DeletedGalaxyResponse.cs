using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Galaxy;

public class DeletedGalaxyResponse : IDeletedResponse
{
    public int Id { get; set; }
}
