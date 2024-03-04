using Microsoft.EntityFrameworkCore;
using NLayerDataAccess.Concretes.EntityFramework.Configuration;
using NLayerEntities.Concretes;

namespace NLayerDataAccess.Concretes.EntityFramework
{
    public class FantasticUniverseProjectContext : DbContext
    {
        //public DbSet<T> Entities { get; set; }
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
    }
}
