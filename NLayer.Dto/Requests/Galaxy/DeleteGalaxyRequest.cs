using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.Galaxy;

public class DeleteGalaxyRequest : IDeleteRequest
{
    public int Id { get; set; }
}
