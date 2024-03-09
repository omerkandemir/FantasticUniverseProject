using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration;

public class GalaxyConfiguration : BaseEntityConfiguration<Galaxy>
{
    public override void Configure(EntityTypeBuilder<Galaxy> builder)
    {
        base.Configure(builder);
        builder.ToTable("Galaxies");
        builder.Property(x => x.UniverseId).HasColumnName("UniverseId");
        builder.Property(x => x.Name).HasColumnName("Name");
        //One to many
        builder.
            HasMany(x => x.Stars).
            WithOne(x => x.Galaxy).
            HasForeignKey(x => x.GalaxyId);
    }
}
