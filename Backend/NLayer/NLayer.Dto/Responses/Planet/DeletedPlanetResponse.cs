using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.Planet;

public class DeletedPlanetResponse : IDeletedResponse
{
    public int Id { get; set; }
}
