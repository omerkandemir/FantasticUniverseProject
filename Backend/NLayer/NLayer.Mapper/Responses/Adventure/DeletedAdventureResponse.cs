using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Adventure;

public class DeletedAdventureResponse : IDeletedResponse
{
    public int Id { get; set; }
}
