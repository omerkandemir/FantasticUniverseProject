using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration;

public class AdventureCollectionConfiguration : BaseEntityConfiguration<AdventureCollection>
{
    public override void Configure(EntityTypeBuilder<AdventureCollection> builder)
    {
        base.Configure(builder);
        builder.ToTable("AdventureCollections");
        builder.Property(x => x.Name).HasColumnName("Name")
            .IsRequired();

        builder.
            HasMany(x => x.AdventureCollectionItems).
            WithOne(x => x.AdventureCollection).
            HasForeignKey(x => x.AdventureCollectionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
