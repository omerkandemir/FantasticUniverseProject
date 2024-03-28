using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Requests.Ability;

public class CreateAbilityRequest : ICreateRequest
{
    public string Name { get; set; }
}
