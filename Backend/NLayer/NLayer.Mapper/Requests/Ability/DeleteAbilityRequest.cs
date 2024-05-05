using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Ability;

public class DeleteAbilityRequest : IDeleteRequest
{
    public int Id { get; set; }
}
