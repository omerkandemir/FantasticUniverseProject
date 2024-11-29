using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration;

    public class StarConfiguration : BaseEntityConfiguration<Star>
    {
        public override void Configure(EntityTypeBuilder<Star> builder)
        {
            base.Configure(builder);
            builder.ToTable("Stars");
            builder.Property(x => x.GalaxyId).HasColumnName("GalaxyId");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.
                HasMany(x => x.Planets).
                WithOne(x => x.Star).
                HasForeignKey(x => x.StarId);
        }
    }
