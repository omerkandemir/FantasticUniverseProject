using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Adventure;

public class DeleteAdventureRequest : IDeleteRequest
{
    public int Id { get; set; }
}
