using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration;

public class UniverseImageConfiguration : BaseEntityConfiguration<UniverseImage>
{
    public override void Configure(EntityTypeBuilder<UniverseImage> builder)
    {
        base.Configure(builder);
        builder.ToTable("UniverseImages");
        builder.Property(x => x.ImageURL).HasColumnName("ImageURL");
        builder.Property(x => x.UniverseId).HasColumnName("UniverseId");
    }
}
