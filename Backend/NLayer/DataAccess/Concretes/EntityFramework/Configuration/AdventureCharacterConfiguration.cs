using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration
{
    public class AdventureCharacterConfiguration : BaseEntityConfiguration<AdventureCharacter>
    {
        public override void Configure(EntityTypeBuilder<AdventureCharacter> builder)
        {
            base.Configure(builder);
            builder.ToTable("AdventureCharacters");
            builder.Property(x => x.AdventureId).HasColumnName("AdventureId");
            builder.Property(x => x.CharacterId).HasColumnName("CharacterId");
        }
    }
}
