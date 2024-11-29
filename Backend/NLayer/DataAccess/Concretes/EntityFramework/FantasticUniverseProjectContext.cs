using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entities.Abstract;
using NLayer.Core.Entities.Authentication;
using NLayer.Core.Entities.Concrete;
using NLayer.Core.Utilities.UserOperations;
using NLayer.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;
using System.Data;

namespace NLayer.DataAccess.Concretes.EntityFramework;

public class FantasticUniverseProjectContext : IdentityDbContext<AppUser, AppRole, int> // IdentityDbContext, DbContext sınıfından miras alır
{    
    public DbSet<Ability> Abilities { get; set; }
    public DbSet<AbilityCategory> AbilityCategories { get; set; }
    public DbSet<AbilityCharacter> AbilityCharacters { get; set; }
    public DbSet<AbilityType> AbilityTypes { get; set; }
    public DbSet<Adventure> Adventures { get; set; }
    public DbSet<AdventureAlternativePaths> AdventureAlternativePaths { get; set; }
    public DbSet<AdventureCharacter> AdventureCharacters { get; set; }
    public DbSet<AdventureCollection> AdventureCollections { get; set; }
    public DbSet<AdventureCollectionItem> AdventureCollectionItems { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Galaxy> Galaxies { get; set; }
    public DbSet<Planet> Planets { get; set; }
    public DbSet<Species> Species { get; set; }
    public DbSet<Star> Stars { get; set; }
    public DbSet<ThemeSetting> ThemeSettings { get; set; }
    public DbSet<TimeLine> TimeLines { get; set; }
    public DbSet<UnionCharacter> UnionCharacters { get; set; }
    public DbSet<Union> Unions { get; set; }
    public DbSet<Universe> Universes { get; set; }
    public DbSet<UniverseImage> UniverseImages { get; set; }
    public DbSet<UserImage> UserImages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\Omer; Initial Catalog = FantasticUniverseProjectDb; Trusted_Connection=True; MultipleActiveResultSets=true");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AbilityConfiguration());
        modelBuilder.ApplyConfiguration(new AbilityCategoryConfiguration());
        modelBuilder.ApplyConfiguration(new AbilityCharacterConfiguration());
        modelBuilder.ApplyConfiguration(new AbilityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new AdventureConfiguration());
        modelBuilder.ApplyConfiguration(new AdventureAlternativePathsConfiguration());
        modelBuilder.ApplyConfiguration(new AdventureCharacterConfiguration());
        modelBuilder.ApplyConfiguration(new AdventureCollectionConfiguration());
        modelBuilder.ApplyConfiguration(new AdventureCollectionItemConfiguration());
        modelBuilder.ApplyConfiguration(new CharacterConfiguration());
        modelBuilder.ApplyConfiguration(new GalaxyConfiguration());
        modelBuilder.ApplyConfiguration(new PlanetConfiguration());
        modelBuilder.ApplyConfiguration(new SpeciesConfiguration());
        modelBuilder.ApplyConfiguration(new StarConfiguration());
        modelBuilder.ApplyConfiguration(new ThemeSettingConfiguration());
        modelBuilder.ApplyConfiguration(new TimeLineConfiguration());
        modelBuilder.ApplyConfiguration(new UnionCharacterConfiguration());
        modelBuilder.ApplyConfiguration(new UnionConfiguration());
        modelBuilder.ApplyConfiguration(new UniverseConfiguration());
        modelBuilder.ApplyConfiguration(new UniverseImageConfiguration());
        modelBuilder.ApplyConfiguration(new UserImageConfiguration());
        base.OnModelCreating(modelBuilder);
    }
    public override int SaveChanges()
    {
        var userId = AccessUser.GetUserId();
        OnBeforeSaving(userId);
        return base.SaveChanges();
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var userId = AccessUser.GetUserId();
        OnBeforeSaving(userId);
        return await base.SaveChangesAsync(cancellationToken);
    }
    protected virtual void OnBeforeSaving(int userId)
    {
        this.ChangeTracker.DetectChanges();
        var added = this.ChangeTracker.Entries()
            .Where(t => t.Entity is IEntity && t.State == EntityState.Added)
            .Select(t => t.Entity)
            .ToArray();
        foreach (var entity in added)
        {
            if (entity is IEntity)
            {
                var track = entity as IEntity;
                this.Entry(entity).Property(nameof(IEntity.UpdatedDate)).IsModified = false;
                this.Entry(entity).Property(nameof(IEntity.DeletedDate)).IsModified = false;
                track.CreatedDate = GetDbDateTime();
                track.IsActive = true;
                track.CreatedBy = userId;
            }
        }
        var modified = this.ChangeTracker.Entries()
            .Where(t => t.Entity is IEntity && t.State == EntityState.Modified)
            .Select(t => t.Entity)
            .ToArray();

        foreach (var entity in modified)
        {
            if (entity is IEntity)
            {
                var track = entity as IEntity;
                this.Entry(entity).Property(nameof(IEntity.UpdatedDate)).IsModified = true;
                this.Entry(entity).Property(nameof(IEntity.CreatedDate)).IsModified = false;
                track.UpdatedDate = GetDbDateTime();
                track.IsActive = true;
                track.ModifiedBy = userId;
            }
        }
    }
    private DateTime GetDbDateTime()
    {
        using (var context = new FantasticUniverseProjectContext())
        {
            using (var connection = context.Database.GetDbConnection())
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                var command = connection.CreateCommand();
                command.CommandText = "select SYSDATETIME()";
                return (DateTime)command.ExecuteScalar();
            }
        }
    }

}
