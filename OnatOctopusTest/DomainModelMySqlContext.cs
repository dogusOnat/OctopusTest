using System;
using System.Linq; 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnatOctopusTest.Models;

namespace DataAccessMySqlProvider
{
    // >dotnet ef migration add testMigration
    public class DomainModelMySqlContext : DbContext
    {
        public DomainModelMySqlContext(DbContextOptions<DomainModelMySqlContext> options) : base(options)
        { }

        public DbSet<Word> Words { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        { 
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            updateUpdatedProperty<Word>(); 

            return base.SaveChanges();
        }

        private void updateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified); 
           
        }
    }
}