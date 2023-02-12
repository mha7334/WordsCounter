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
    public IActionResult WordCounter([Required][FromBody] WordsCounterRequest wordsCounterRequest)
    {

        var result = _wordsCounterService.CountWords(wordsCounterRequest.Paragraph).Result;

        WordsCounterResponse response = new(result.Item1, result.Item2);

        return Ok(response);
    }
}