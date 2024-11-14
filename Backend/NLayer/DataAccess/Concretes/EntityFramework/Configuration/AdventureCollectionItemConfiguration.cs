using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration;

public class AdventureCollectionItemConfiguration : BaseEntityConfiguration<AdventureCollectionItem>
{
    public override void Configure(EntityTypeBuilder<AdventureCollectionItem> builder)
    {

        base.Configure(builder);

        builder.ToTable("AdventureCollectionItems");
        builder.Property(x => x.OrderIndex).HasColumnName("OrderIndex");
        builder.Property(x => x.AdventureCollectionId).HasColumnName("AdventureCollectionId");
        builder.Property(x => x.AdventureId).HasColumnName("AdventureId");
        builder.Property(x => x.NextAdventureId).HasColumnName("NextAdventureId");

        // Self-referencing relationship for NextAdventureId
        builder.HasOne(x => x.NextAdventure)
          .WithMany()
          .HasForeignKey(x => x.NextAdventureId)
          .OnDelete(DeleteBehavior.Restrict); // Sıradaki bir sonraki macera

        // Relationship with AdventureAlternativePaths
        builder.HasMany(x => x.AlternativePaths)
            .WithOne(x => x.AdventureCollectionItem)
            .HasForeignKey(x => x.AdventureCollectionItemId)
            .OnDelete(DeleteBehavior.Cascade); // İlişkili kayıtlar otomatik güncellenecek
    }
}
