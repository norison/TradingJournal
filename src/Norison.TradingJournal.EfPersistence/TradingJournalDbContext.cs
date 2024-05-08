using Microsoft.EntityFrameworkCore;
using Norison.TradingJournal.EfPersistence.Entities;

namespace Norison.TradingJournal.EfPersistence;

public class TradingJournalDbContext(DbContextOptions<TradingJournalDbContext> options) : DbContext(options)
{
    public DbSet<AccountEntity> Accounts { get; set; }

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