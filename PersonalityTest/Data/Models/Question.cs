namespace PersonalityTest.Data.Models;

public class Question : BaseEntity<int>
{
    public string Text { get; set; }
    public List<Option> Options { get; set; }
}
