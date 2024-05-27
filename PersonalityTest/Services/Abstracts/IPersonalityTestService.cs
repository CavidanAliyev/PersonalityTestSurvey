using PersonalityTest.Contracts.Response;
using PersonalityTest.Contracts.Request;

namespace PersonalityTest.Services.Abstracts;

public interface IPersonalityTestService
{
    Task<List<GetQuestionDTO>> GetQuestionsAsync();
    Task<GetResultResponseDTO> GetPersonalityResultAsync(List<GetResultRequestDTO> answers);
}
