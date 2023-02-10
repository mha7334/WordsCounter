public interface IWordsCounterService
{
    (int, IEnumerable<string>) CountWords(string paragraph);
}