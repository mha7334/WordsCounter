using WordsCounter.Domain.Entities;

namespace WordsCounter.Application.Interfaces
{
    public interface IWatchlistRepository
    {
        IQueryable<WatchlistWord> GetWords();
    }
}
