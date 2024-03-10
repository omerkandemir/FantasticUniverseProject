using NLayer.Core.Entities.Concrete;

namespace NLayer.Entities.Concretes;

public class Character : BaseEntity<int>
{
    public int? AbilityId { get; set; }
    public Ability Ability { get; set; }
    public int? SpeciesId { get; set; }
    public Species Species { get; set; }
    public string Name { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public int? MasterCharacterId { get; set; }
    public int? ApprenticeId { get; set; }
    public ICollection<UnionCharacter> UnionCharacters { get; set; }
    public ICollection<AdventureCharacter> AdventureCharacters { get; set; }
}
