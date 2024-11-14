using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration;

public class ThemeSettingConfiguration : BaseEntityConfiguration<ThemeSetting>
{
    public override void Configure(EntityTypeBuilder<ThemeSetting> builder)
    {
        base.Configure(builder);

        builder.ToTable("ThemeSettings");
        builder.Property(x => x.Background).HasColumnName("Background");
        builder.Property(x => x.FontColorR).HasColumnName("FontColorR");
        builder.Property(x => x.FontColorG).HasColumnName("FontColorG");
        builder.Property(x => x.FontColorB).HasColumnName("FontColorB");
        builder.Property(x => x.FontFamily).HasColumnName("FontFamily");
        builder.
            HasMany(x => x.Universes).
            WithOne(x => x.ThemeSetting).
            HasForeignKey(x => x.ThemeSettingId);
    }
}