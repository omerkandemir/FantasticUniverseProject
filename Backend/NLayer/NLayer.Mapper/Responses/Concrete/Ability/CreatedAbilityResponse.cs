using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.Ability;

public class CreatedAbilityResponse : ICreatedResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
}
