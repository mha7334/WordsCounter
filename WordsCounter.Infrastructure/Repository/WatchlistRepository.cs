using WordsCounter.Application.Interfaces;
using WordsCounter.Domain.Entities;

namespace WordsCounter.Infrastructure.Repository
{
    public class WatchlistRepository : IWatchlistRepository
    {
        private readonly WatchlistDbContext _context;

        public WatchlistRepository(WatchlistDbContext dbContext)
        {
            _context = dbContext;
        }
        IQueryable<WatchlistWord> IWatchlistRepository.GetWords()
        {
            return _context.Watchlist;
        }
    }
}
