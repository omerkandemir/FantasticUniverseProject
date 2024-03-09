using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.Ability;

public class DeleteAbilityRequest : IDeleteRequest
{
    public int Id { get; set; }
}
