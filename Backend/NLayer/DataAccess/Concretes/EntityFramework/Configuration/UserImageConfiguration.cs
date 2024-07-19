using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Core.Entities.Concrete;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration;

public class UserImageConfiguration : BaseEntityConfiguration<UserImage>
{
    public override void Configure(EntityTypeBuilder<UserImage> builder)
    {
        base.Configure(builder);
        builder.ToTable("UserImages");
        builder.Property(x => x.UserId).HasColumnName("UserId");
        builder.Property(x => x.UniverseImageId).HasColumnName("UniverseImageId");
    }
}
