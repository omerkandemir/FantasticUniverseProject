using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Planet;

public class DeletePlanetRequest : IDeleteRequest
{
    public int Id { get; set; }
}
