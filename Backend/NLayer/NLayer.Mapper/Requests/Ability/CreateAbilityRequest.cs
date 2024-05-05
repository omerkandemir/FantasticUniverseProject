using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Ability;

public class CreateAbilityRequest : ICreateRequest
{
    public string Name { get; set; }
}
