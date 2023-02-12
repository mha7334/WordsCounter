using WordsCounter.Application.Interfaces;
using WordsCounter.Domain.Entities;

namespace WordsCounter.Application.Services;
public class WordsCounterService : IWordsCounterService
{
    private readonly IRepository<Watchlist> _watchlistRepository;
    private readonly IRepository<Stats> _statsRepository;
    private readonly IRepository<StatsWatchlist> _statsWatchlistRepository;


    public WordsCounterService(IRepository<Watchlist> watchlistRepository,
                                IRepository<Stats> statsRepository,
                                IRepository<StatsWatchlist> statsWatchlistRepository)
    {
        _watchlistRepository = watchlistRepository;
        _statsRepository = statsRepository;
        _statsWatchlistRepository = statsWatchlistRepository;
    }

    public async Task<(int, IEnumerable<string>)> CountWords(string paragraph)
    {

        var words = paragraph.Split(new[] { ' ', '.', ',', ';', ':', '!', '?' },
                                    StringSplitOptions.RemoveEmptyEntries);

        var watchList = _watchlistRepository.GetAllAsync().Result.ToList();
        var watchListWords = watchList.Select(w => w.Word).ToList();

        var uniqueWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var uniqueWordsInWatchlist = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        Parallel.ForEach(words, word =>
        {
            uniqueWords.Add(word);
            if (watchListWords.Contains(word, StringComparer.OrdinalIgnoreCase))
            {
                uniqueWordsInWatchlist.Add(word);
            }
        });

        Stats stats = new(default, uniqueWords.Count);

        var result = await _statsRepository.AddAsync(stats);

        List<StatsWatchlist> statsWatchlist = new();
        foreach (var word in uniqueWordsInWatchlist)
        {
            int wordId = watchList.First(w => w.Word.Equals(word)).Id;
            await _statsWatchlistRepository.AddAsync(new StatsWatchlist(result.Id, wordId));
            statsWatchlist.Add(new StatsWatchlist(result.Id, wordId));
        }

        return (uniqueWords.Count, uniqueWordsInWatchlist.AsEnumerable());
    }
}
