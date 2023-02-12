using Microsoft.EntityFrameworkCore;
using WordsCounter.Domain.Entities;

namespace WordsCounter.Infrastructure;

public class WordsCounterDbContext : DbContext
{
    public WordsCounterDbContext(DbContextOptions<WordsCounterDbContext> options)
        : base(options)
    {
    }

    public DbSet<Watchlist> Watchlist { get; set; }
    public DbSet<Stats> Stats { get; set; }
    public DbSet<StatsWatchlist> StatsWatchlist { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StatsWatchlist>().HasKey(sw => new { sw.StatsId, sw.WatchlistId });
    }
}

