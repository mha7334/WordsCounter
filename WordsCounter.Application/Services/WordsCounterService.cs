using WordsCounter.Application.Interfaces;

namespace WordsCounter.Application.Services;
public class WordsCounterService : IWordsCounterService
{
    private readonly IWatchlistRepository _watchlistRepository;

    public WordsCounterService(IWatchlistRepository watchlistRepository)
    {
        _watchlistRepository = watchlistRepository;
    }

    public (int, IEnumerable<string>) CountWords(string paragraph)
    {
        var wordSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var words = paragraph.Split(new[] { ' ', '.', ',', ';', ':', '!', '?' },
                                    StringSplitOptions.RemoveEmptyEntries);

        var watchlist = _watchlistRepository.GetWords().Select(w => w.Word).ToList();

        Parallel.ForEach(words, word =>
        {
            if (watchlist.Contains(word, StringComparer.OrdinalIgnoreCase))
                wordSet.Add(word);
        });

        return (words.Count(), wordSet.AsEnumerable());
    }
}
