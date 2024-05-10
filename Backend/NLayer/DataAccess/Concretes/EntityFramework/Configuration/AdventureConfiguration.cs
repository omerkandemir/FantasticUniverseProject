using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration;

public class AdventureConfiguration : BaseEntityConfiguration<Adventure>
{
    public override void Configure(EntityTypeBuilder<Adventure> builder)
    {
        base.Configure(builder);
        builder.ToTable("Adventures");
        builder.Property(x => x.PlanetId).HasColumnName("PlanetId");
        builder.Property(x => x.AdventureName).HasColumnName("AdventureName");
        builder.Property(x => x.AdventureContent).HasColumnName("AdventureContent");
        builder.Property(x => x.StartTime).HasColumnName("StartTime");
        builder.Property(x => x.EndTime).HasColumnName("EndTime");
        builder.
            HasMany(x => x.TimeLines).
            WithOne(x => x.Adventure).
            HasForeignKey(x => x.StartingAdventureId);
        builder.
            HasMany(x => x.AdventureCharacters).
            WithOne(x => x.Adventure).
            HasForeignKey(x=>x.AdventureId);
    }
}
