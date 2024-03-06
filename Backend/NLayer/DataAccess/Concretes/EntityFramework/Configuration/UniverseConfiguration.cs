using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration
{
    public class UniverseConfiguration : BaseEntityConfiguration<Universe>
    {
        public override void Configure(EntityTypeBuilder<Universe> builder)
        {
            base.Configure(builder);
            builder.ToTable("Universes");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.TimeLineId).HasColumnName("TimeLineId");
            
            //One to many
            builder.
                HasMany(x => x.Unions).
                WithOne(x => x.Universe).
                HasForeignKey(x => x.UniverseId);
            builder.
                HasMany(x => x.Galaxies).
                WithOne(x => x.Universe).
                HasForeignKey(x => x.UniverseId);
        }
    }
}
