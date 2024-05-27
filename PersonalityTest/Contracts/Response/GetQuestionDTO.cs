namespace PersonalityTest.Contracts.Response;

public record GetQuestionDTO
{
    public int Id { get; set; }
    public string Text { get; set; }
    public List<OptionDTO> Options { get; set; }
}

public record OptionDTO
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int Score { get; set; }
    public int QuestionId { get; set; }
}
