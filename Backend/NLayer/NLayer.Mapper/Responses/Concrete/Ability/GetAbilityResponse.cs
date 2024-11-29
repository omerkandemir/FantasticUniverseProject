using NLayer.Mapper.Responses.Abstract;

namespace NLayer.Mapper.Responses.Concrete.Ability;

public class GetAbilityResponse : IGetAbilityResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
}
