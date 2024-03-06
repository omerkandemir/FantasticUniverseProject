using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration
{
    public class TimeLineConfiguration : BaseEntityConfiguration<TimeLine>
    {
        public override void Configure(EntityTypeBuilder<TimeLine> builder)
        {
            base.Configure(builder);
            builder.ToTable("TimeLines");
            builder.Property(x => x.StartingAdventureId).HasColumnName("StartingAdventureId");
            //One to many
            builder.
                HasMany(x => x.Universes).
                WithOne(x => x.TimeLine).
                HasForeignKey(x => x.TimeLineId);
        }
    }
}
