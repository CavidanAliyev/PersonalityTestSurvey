namespace PersonalityTest.UI.Models;

public class Question
{
    public int Id { get; set; }
    public string Text { get; set; }
    public List<Option> Options { get; set; }
}

public record Option
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int Score { get; set; }
    public int QuestionId { get; set; }
}
