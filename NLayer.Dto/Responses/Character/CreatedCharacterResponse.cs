using NLayer.Core.Dto.Abstracts;

namespace NLayer.Dto.Responses.Character;

public class CreatedCharacterResponse : ICreatedResponse
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int? AbilityId { get; set; }
    public int? SpeciesId { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public int? MasterCharacterId { get; set; }
    public int? ApprenticeId { get; set; }
}
