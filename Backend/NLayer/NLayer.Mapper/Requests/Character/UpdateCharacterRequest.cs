using NLayer.Core.Dto.Abstracts;

namespace NLayer.Mapper.Requests.Character;

public class UpdateCharacterRequest : IUpdateRequest
{
    public int Id { get; set; }
    public int? SpeciesId { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public int? MasterCharacterId { get; set; }
    public int? ApprenticeId { get; set; }

}
