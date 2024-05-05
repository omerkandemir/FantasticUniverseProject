using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Galaxy;

public class DeleteGalaxyRequest : IDeleteRequest
{
    public int Id { get; set; }
}
