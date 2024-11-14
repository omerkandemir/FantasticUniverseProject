using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration;

public class AbilityTypeConfiguration : BaseEntityConfiguration<AbilityType>
{
    public override void Configure(EntityTypeBuilder<AbilityType> builder)
    {
        base.Configure(builder);

        builder.ToTable("AbilityTypes");
        builder.Property(x => x.TypeName).HasColumnName("TypeName");
        builder.Property(x => x.Description).HasColumnName("Description");
        builder.
            HasMany(x => x.Abilities).
            WithOne(x => x.AbilityType).
            HasForeignKey(x => x.AbilityTypeId);
    }
}
