public interface IWordsCounterService
{
    Task<(int Counts, IEnumerable<string> WordsInWatchlist)> CountWords(string paragraph);
}