﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework.Configuration;

public class AbilityConfiguration : BaseEntityConfiguration<Ability>
{
    public override void Configure(EntityTypeBuilder<Ability> builder)
    {
        base.Configure(builder);
        builder.ToTable("Abilities");
        builder.Property(x => x.Name).HasColumnName("Name");
        builder.Property(x => x.AbilityTypeId).HasColumnName("AbilityTypeId");
        builder.Property(x => x.AbilityCategoryId).HasColumnName("AbilityCategoryId");
        builder.
            HasMany(x=>x.AbilityCharacters).
            WithOne(x=>x.Ability).
            HasForeignKey(x=>x.AbilityId);
    }
}
