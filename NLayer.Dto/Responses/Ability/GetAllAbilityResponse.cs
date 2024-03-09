using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.Ability;

public class GetAllAbilityResponse : IGetAllResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
}
