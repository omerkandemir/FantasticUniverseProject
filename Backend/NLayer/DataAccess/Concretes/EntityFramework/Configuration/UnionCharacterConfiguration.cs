﻿using Microsoft.EntityFrameworkCore;
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
    public class UnionCharacterConfiguration : BaseEntityConfiguration<UnionCharacter>
    {
        public override void Configure(EntityTypeBuilder<UnionCharacter> builder)
        {
            base.Configure(builder);
            builder.ToTable("UnionCharacters");
            builder.Property(x => x.UnionId).HasColumnName("UnionId");
            builder.Property(x => x.CharacterId).HasColumnName("CharacterId");
        }
    }
}
