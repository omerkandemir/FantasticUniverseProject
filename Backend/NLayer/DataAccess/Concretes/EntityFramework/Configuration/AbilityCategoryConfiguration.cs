using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration;

public class AbilityCategoryConfiguration : BaseEntityConfiguration<AbilityCategory>
{
    public override void Configure(EntityTypeBuilder<AbilityCategory> builder)
    {
        base.Configure(builder);

        builder.ToTable("AbilityCategories");
        builder.Property(x => x.CategoryName).HasColumnName("CategoryName");
        builder.Property(x => x.Description).HasColumnName("Description");
        builder.
            HasMany(x => x.Abilities).
            WithOne(x => x.AbilityCategory).
            HasForeignKey(x => x.AbilityCategoryId);
    }
}
