using WordsCounter.Domain.Entities;

namespace WordsCounter.Application.Interfaces
{
    public interface IWatchlistRepository1
    {
        IQueryable<Watchlist> GetWords();
    }
}
