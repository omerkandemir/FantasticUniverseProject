using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NLayer.Core.Entities.Abstract;
using NLayer.Core.Entities.Authentication;
using NLayer.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;
using System.Data;

namespace NLayer.DataAccess.Concretes.EntityFramework;

public class FantasticUniverseProjectContext : IdentityDbContext<AppUser, AppRole, int> // IdentityDbContext, DbContext sınıfından miras alır
{
    
    private int _userId;
    public DbSet<Ability> Abilities { get; set; }
    public DbSet<AbilityCharacter> AbilityCharacters { get; set; }
    public DbSet<AdventureCharacter> AdventureCharacters { get; set; }
    public DbSet<Adventure> Adventures { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Galaxy> Galaxies { get; set; }
    public DbSet<Planet> Planets { get; set; }
    public DbSet<Species> Species { get; set; }
    public DbSet<Star> Stars { get; set; }
    public DbSet<TimeLine> TimeLines { get; set; }
    public DbSet<UnionCharacter> UnionCharacters { get; set; }
    public DbSet<Union> Unions { get; set; }
    public DbSet<Universe> Universes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\Omer; Initial Catalog = FantasticUniverseProjectDb;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AbilityConfiguration());
        modelBuilder.ApplyConfiguration(new AbilityCharacterConfiguration());
        modelBuilder.ApplyConfiguration(new AdventureConfiguration());
        modelBuilder.ApplyConfiguration(new AdventureCharacterConfiguration());
        modelBuilder.ApplyConfiguration(new CharacterConfiguration());
        modelBuilder.ApplyConfiguration(new GalaxyConfiguration());
        modelBuilder.ApplyConfiguration(new PlanetConfiguration());
        modelBuilder.ApplyConfiguration(new SpeciesConfiguration());
        modelBuilder.ApplyConfiguration(new StarConfiguration());
        modelBuilder.ApplyConfiguration(new TimeLineConfiguration());
        modelBuilder.ApplyConfiguration(new UnionCharacterConfiguration());
        modelBuilder.ApplyConfiguration(new UnionConfiguration());
        modelBuilder.ApplyConfiguration(new UniverseConfiguration());
        base.OnModelCreating(modelBuilder);
    }
    public override int SaveChanges()
    {
        var httpContext = GetHttpContext();
        _userId = Convert.ToInt32(httpContext?.Items["UserId"]);
        OnBeforeSaving();
        return base.SaveChanges();
    }
    private HttpContext GetHttpContext()
    {
        var serviceProvider = this.GetInfrastructure();
        var httpContextAccessor = serviceProvider.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
        return httpContextAccessor?.HttpContext;
    }
    protected virtual void OnBeforeSaving()
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
                track.CreatedBy = _userId;
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
                track.ModifiedBy = _userId;
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
