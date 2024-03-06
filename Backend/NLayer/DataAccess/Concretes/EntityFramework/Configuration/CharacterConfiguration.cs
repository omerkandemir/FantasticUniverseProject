using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration
{
    public class CharacterConfiguration : BaseEntityConfiguration<Character>
    {
        public override void Configure(EntityTypeBuilder<Character> builder)
        {
            base.Configure(builder);
            builder.ToTable("Characters");
            builder.Property(x => x.AbilityId).HasColumnName("AbilityId");
            builder.Property(x => x.SpeciesId).HasColumnName("SpeciesId");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.BirthDate).HasColumnName("BirthDate");
            builder.Property(x => x.DeathDate).HasColumnName("DeathDate");
            builder.Property(x => x.UnionId).HasColumnName("UnionId");
            builder.Property(x => x.MasterCharacterId).("MasterCharacterId");
            builder.Property(x => x.ApprenticeId).HasColumnName("ApprenticeId");
            //One to many
            builder.
                HasMany(x => x.Unions).
                WithOne(x => x.Character).
                HasForeignKey(x => x.UnionLeaderId);
            builder.
                HasMany(x=>x.Adventures).
                WithOne(x=>x.Character)
                .HasForeignKey(x=>x.CharacterId);
        }
    }
}
