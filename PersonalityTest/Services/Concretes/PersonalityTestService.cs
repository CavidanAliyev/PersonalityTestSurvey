using PersonalityTest.Infrastructure.Options;
using PersonalityTest.Contracts.Response;
using PersonalityTest.Services.Abstracts;
using PersonalityTest.Contracts.Request;
using Microsoft.Extensions.Options;
using PersonalityTest.Data.Models;
using PersonalityTest.Data.Enums;
using Newtonsoft.Json;
using AutoMapper;

namespace PersonalityTest.Services.Concretes;

public class PersonalityTestService : IPersonalityTestService
{
    private const int AverageScore = 40;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly MockServerOptions _mockServerOptions;
    private readonly IMapper _mapper;

    public PersonalityTestService(IHttpClientFactory httpClientFactory,
       IOptions<MockServerOptions> mockServerOptions,
       IMapper mapper)
    {
        _httpClientFactory = httpClientFactory;
        _mockServerOptions = mockServerOptions.Value;
        _mapper = mapper;
    }

    public async Task<GetResultResponseDTO> GetPersonalityResultAsync(List<GetResultRequestDTO> answers)
    {
        var questions = await GetQuestionsFromMockServerAsync();

        var options = questions.SelectMany(x => x.Options);
        int score = default;

        foreach (var answer in answers)
        {
            var option = options.SingleOrDefault(o => o.Id == answer.SelectedOptionId && o.QuestionId == answer.QuestionId);

            if (option is null)
                throw new Exception("Option is not found");

            score += option.Score;
        }

        var trait = GetScoreByPersonalityType(score).ToString();
        var result = new GetResultResponseDTO(trait);

        return result;
    }

    public async Task<List<GetQuestionDTO>> GetQuestionsAsync()
    {
        var questions = await GetQuestionsFromMockServerAsync();

        return _mapper.Map<List<GetQuestionDTO>>(questions);
    }

    private async Task<List<Question>> GetQuestionsFromMockServerAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage response = await client.GetAsync(_mockServerOptions.Questions);

        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Question>>(result);
        }
        else
            throw new Exception("Internal server error");
    }

    private PersonalityType GetScoreByPersonalityType(int score)
    {
        return score > AverageScore ? PersonalityType.Extrovert : PersonalityType.Introvert;
    }
}
