using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.Adventure;

public class DeleteAdventureRequest : IDeleteRequest
{
    public int Id { get; set; }
}
