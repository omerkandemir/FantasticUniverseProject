using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration;

public class UnionConfiguration : BaseEntityConfiguration<Union>
{
    public override void Configure(EntityTypeBuilder<Union> builder)
    {
        base.Configure(builder);
        builder.ToTable("Unions");
        builder.Property(x => x.Name).HasColumnName("Name");
        builder.Property(x => x.Target).HasColumnName("Target");
        builder.Property(x => x.UnionLeaderId).HasColumnName("UnionLeaderId");
        builder.Property(x => x.UniverseId).HasColumnName("UniverseId");
        //One to many
        builder.
            HasMany(x => x.UnionCharacters).
            WithOne(x => x.Union).
            HasForeignKey(x => x.UnionId);
    }
}
