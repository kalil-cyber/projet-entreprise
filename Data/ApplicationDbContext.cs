using Microsoft.EntityFrameworkCore;
using mac.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace mac.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Departement> Departements { get; set; }
        public DbSet<Salarie> Salaries { get; set; }
        public DbSet<Projet> Projets { get; set; }

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is Departement || e.Entity is Salarie || e.Entity is Projet);

            var now = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Property("CreatedAt") != null)
                        entry.Property("CreatedAt").CurrentValue = now;
                    if (entry.Property("UpdatedAt") != null)
                        entry.Property("UpdatedAt").CurrentValue = now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    if (entry.Property("UpdatedAt") != null)
                        entry.Property("UpdatedAt").CurrentValue = now;
                }
            }
        }
    }
}

