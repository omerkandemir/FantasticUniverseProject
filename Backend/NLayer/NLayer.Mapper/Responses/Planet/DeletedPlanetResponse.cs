using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Planet;

public class DeletedPlanetResponse : IDeletedResponse
{
    public int Id { get; set; }
}
