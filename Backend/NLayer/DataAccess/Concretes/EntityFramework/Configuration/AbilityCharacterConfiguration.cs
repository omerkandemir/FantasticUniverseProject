using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration;

public class AbilityCharacterConfiguration : BaseEntityConfiguration<AbilityCharacter>
{
    public override void Configure(EntityTypeBuilder<AbilityCharacter> builder)
    {
        base.Configure(builder);
        builder.ToTable("AbilityCharacters");
        builder.Property(x => x.AbilityId).HasColumnName("AbilityId");
        builder.Property(x => x.CharacterId).HasColumnName("CharacterId");
    }
}
