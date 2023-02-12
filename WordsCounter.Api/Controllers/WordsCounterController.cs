using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using WordsCounter.Contracts;

[ApiController]
[Route("Api")]
public class WordsCounterController : ControllerBase
{

    public readonly IWordsCounterService _wordsCounterService;
    public WordsCounterController(IWordsCounterService wordsCounterService)
    {
        _wordsCounterService = wordsCounterService;
    }

    [Route("Paragraph")]
    [HttpPost]
    public async Task<IActionResult> WordCounter([Required][FromBody] WordsCounterRequest wordsCounterRequest)
    {

        var result = await _wordsCounterService.CountWords(wordsCounterRequest.Paragraph);

        WordsCounterResponse response = new(result.Counts, result.WordsInWatchlist);

        return Ok(response);
    }
}