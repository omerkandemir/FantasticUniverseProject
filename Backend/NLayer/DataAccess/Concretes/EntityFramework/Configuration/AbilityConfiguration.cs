using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerCore.DataAccess.Concretes.EntityFramework.Configuration;
using NLayerEntities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerDataAccess.Concretes.EntityFramework.Configuration
{
    public class AbilityConfiguration : BaseEntityConfiguration<Ability>
    {
        public override void Configure(EntityTypeBuilder<Ability> builder)
        {
            base.Configure(builder);
            builder.ToTable("Abilities");
            builder.Property(x => x.Name).HasColumnName("Name");
            //One to many
            builder.
                HasMany(x => x.Characters).
                WithOne(x => x.Ability).
                HasForeignKey(x => x.Id);
        }
    }
}
