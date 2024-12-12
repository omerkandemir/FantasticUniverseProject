using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Core.Entities.Authorization;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration;

public class AppRoleConfiguration : BaseEntityConfiguration<AppRole>
{
    public override void Configure(EntityTypeBuilder<AppRole> builder)
    {
        base.Configure(builder);
        builder.ToTable("AspNetRoles");
        builder.Property(x => x.Name).HasColumnName("Name");
        builder.Property(x => x.NormalizedName).HasColumnName("NormalizedName");
        builder.Property(x => x.ConcurrencyStamp).HasColumnName("ConcurrencyStamp");
    }
}