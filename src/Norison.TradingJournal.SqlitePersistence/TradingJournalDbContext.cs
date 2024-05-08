using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Norison.TradingJournal.SqlitePersistence.Entities;

namespace Norison.TradingJournal.SqlitePersistence;

[ExcludeFromCodeCoverage]
public class TradingJournalDbContext : DbContext
{
    public DbSet<AccountEntity> Accounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlite("Data Source=trading-journal.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TradingJournalDbContext).Assembly);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            entityType.ClrType
                .GetProperties()
                .Where(x => x.PropertyType == typeof(decimal))
                .ToList()
                .ForEach(x => modelBuilder
                    .Entity(entityType.Name)
                    .Property(x.Name)
                    .HasConversion<double>());
        }
    }
}