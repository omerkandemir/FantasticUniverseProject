using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Responses.Concrete.Ability;

public class UpdatedAbilityResponse : IUpdatedResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
