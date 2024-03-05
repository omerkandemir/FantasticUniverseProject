using Microsoft.EntityFrameworkCore;
using NLayer.Core.Entities.Abstract;
using NLayer.Core.Entities.Concrete;
using NLayer.DataAccess.Concretes.EntityFramework.Configuration;
using NLayer.Entities.Concretes;

namespace NLayer.DataAccess.Concretes.EntityFramework
{
    public class FantasticUniverseProjectContext : DbContext
    {
        //public DbSet<T> Entities { get; set; }
        //public int UserId { get; set; }
        public DbSet<Ability> Abilities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\Omer; Initial Catalog = EnochDb;");
            }
            // base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AbilityConfiguration());
        }
        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
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
                    track.CreatedDate = DateTime.Now;
                    track.IsActive = true;
                    //track.CreatedBy = UserId;
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
                    this.Entry(entity).Property(nameof(IEntity.CreatedDate)).IsModified = false;
                    track.UpdatedDate = DateTime.Now;
                    track.IsActive = true;
                    //track.ModifiedBy = UserId;
                }
            }
        }
    }
}
