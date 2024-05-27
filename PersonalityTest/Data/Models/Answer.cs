namespace PersonalityTest.Data.Models;

public class Answer : BaseEntity<int>
{
    public int QuestionId { get; set; }
    public Question Question { get; set; }

    public int SelectedOptionId { get; set; }
    public Option Option { get; set; }
}
