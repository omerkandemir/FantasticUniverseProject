using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Entities.Abstract;

namespace NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;

public class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IEntity, new()
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property<int>("Id").HasColumnName("Id");
        builder.HasKey("Id");
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate").ValueGeneratedOnAdd();
        builder.Property(x => x.IsActive).HasColumnName("IsActive");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate").HasDefaultValueSql("getDate()");
        builder.Property(x => x.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy");
        builder.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy");
    }
}
