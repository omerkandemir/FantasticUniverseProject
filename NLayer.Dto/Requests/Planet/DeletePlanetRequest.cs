using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.Planet;

public class DeletePlanetRequest : IDeleteRequest
{
    public int Id { get; set; }
}
