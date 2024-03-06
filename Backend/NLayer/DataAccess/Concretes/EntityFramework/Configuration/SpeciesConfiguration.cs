using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration
{
    public class SpeciesConfiguration : BaseEntityConfiguration<Species>
    {
        public override void Configure(EntityTypeBuilder<Species> builder)
        {
            base.Configure(builder);
            builder.ToTable("Species");
            builder.Property(x => x.Name).HasColumnName("Name");
            //One to many
            builder.
                HasMany(x => x.Characters).
                WithOne(x => x.Species).
                HasForeignKey(x => x.SpeciesId);
        }
    }
}
