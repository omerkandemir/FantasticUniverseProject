using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Ability;

public class UpdateAbilityRequest : IUpdateRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
}
