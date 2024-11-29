using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration;

public class AdventureAlternativePathsConfiguration : BaseEntityConfiguration<AdventureAlternativePaths>
{
    public override void Configure(EntityTypeBuilder<AdventureAlternativePaths> builder)
    {
        base.Configure(builder);

        builder.ToTable("AdventureAlternativePaths");

        builder.Property(x => x.Choice)
    .HasColumnName("Choice")
    .IsRequired(); // Choice alanı gerekli

        builder.Property(x => x.NextAdventureId)
            .HasColumnName("NextAdventureId");

        // Self-referencing relationship for NextAdventure
        builder.HasOne(x => x.NextAdventure)
            .WithMany()
            .HasForeignKey(x => x.NextAdventureId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
