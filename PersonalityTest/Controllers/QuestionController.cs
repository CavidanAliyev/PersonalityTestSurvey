using PersonalityTest.Services.Abstracts;
using PersonalityTest.Contracts.Request;
using Microsoft.AspNetCore.Mvc;

namespace PersonalityTest.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IPersonalityTestService _personalityTestService;

    public QuestionController(IPersonalityTestService personalityTestService)
    {
        _personalityTestService = personalityTestService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var questions = await _personalityTestService.GetQuestionsAsync();
        return Ok(questions);
    }

    [HttpPost("result")]
    public async Task<IActionResult> GetPersonalityResultAsync([FromBody] List<GetResultRequestDTO> dto)
    {
        var result = await _personalityTestService.GetPersonalityResultAsync(dto);
        return Ok(result);
    }
}
