using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration;

public class PlanetConfiguration : BaseEntityConfiguration<Planet>
{
    public override void Configure(EntityTypeBuilder<Planet> builder)
    {
        base.Configure(builder);
        builder.ToTable("Planets");
        builder.Property(x => x.StarId).HasColumnName("StarId");
        builder.Property(x => x.Name).HasColumnName("Name");
        builder.Property(x => x.PlanetAge).HasColumnName("PlanetAge");
        builder.Property(x => x.PlanetTemperature).HasColumnName("PlanetTemperature");
        builder.Property(x => x.PlanetMass).HasColumnName("PlanetMass");
        builder.
            HasMany(x => x.Adventures).
            WithOne(x => x.Planet).
            HasForeignKey(x => x.PlanetId);
    }
}
