namespace PersonalityTest.Data.Models;

public class Option : BaseEntity<int>
{
    public string Text { get; set; }
    public int Score { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; }
}
