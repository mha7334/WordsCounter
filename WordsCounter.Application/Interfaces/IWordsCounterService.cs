public interface IWordsCounterService
{
    Task<(int, IEnumerable<string>)> CountWords(string paragraph);
}