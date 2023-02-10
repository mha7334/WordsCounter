using Microsoft.EntityFrameworkCore;
using WordsCounter.Domain.Entities;

namespace WordsCounter.Infrastructure;

public class WatchlistDbContext : DbContext
{
    public WatchlistDbContext(DbContextOptions<WatchlistDbContext> options)
        : base(options)
    {
    }
    public DbSet<WatchlistWord> Watchlist { get; set; }
}
