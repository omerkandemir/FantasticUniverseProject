using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.Adventure;

public class DeletedAdventureResponse : IDeletedResponse
{
    public int Id { get; set; }
}
