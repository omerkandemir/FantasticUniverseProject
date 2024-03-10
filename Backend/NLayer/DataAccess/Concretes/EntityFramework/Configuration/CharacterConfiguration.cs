using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration;

public class CharacterConfiguration : BaseEntityConfiguration<Character>
{
    public override void Configure(EntityTypeBuilder<Character> builder)
    {
        base.Configure(builder);
        builder.ToTable("Characters");
        builder.Property(x => x.AbilityId).HasColumnName("AbilityId");
        builder.Property(x => x.SpeciesId).HasColumnName("SpeciesId");
        builder.Property(x => x.Name).HasColumnName("Name");
        builder.Property(x => x.BirthDate).HasColumnName("BirthDate");
        builder.Property(x => x.DeathDate).HasColumnName("DeathDate");
        builder.Property(x => x.MasterCharacterId).HasColumnName("MasterCharacterId");
        builder.Property(x => x.ApprenticeId).HasColumnName("ApprenticeId");
        builder.
            HasMany(x => x.UnionCharacters).
            WithOne(x => x.Character).
            HasForeignKey(x => x.CharacterId);
        builder.
            HasMany(x => x.AdventureCharacters).
            WithOne(x => x.Character).
            HasForeignKey(x => x.CharacterId);
    }
}
