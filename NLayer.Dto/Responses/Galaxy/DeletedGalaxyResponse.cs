using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.Galaxy;

public class DeletedGalaxyResponse : IDeletedResponse
{
    public int Id { get; set; }
}
