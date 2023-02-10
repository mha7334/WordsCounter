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

        var words = paragraph.Split(new[] { ' ', '.', ',', ';', ':', '!', '?' },
                                    StringSplitOptions.RemoveEmptyEntries);

        var watchList = _watchlistRepository.GetWords().Select(w => w.Word).ToList();

        var uniqueWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var uniqueWordsInWatchlist = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        Parallel.ForEach(words, word =>
        {
            uniqueWords.Add(word);
            if (watchList.Contains(word, StringComparer.OrdinalIgnoreCase))
            {
                uniqueWordsInWatchlist.Add(word);
            }
        });

        return (uniqueWords.Count, uniqueWordsInWatchlist.AsEnumerable());
    }
}
