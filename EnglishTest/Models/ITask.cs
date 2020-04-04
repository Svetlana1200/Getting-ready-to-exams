namespace EnglishTest.Models
{
    public interface ITask
    {
        string Id { get; set; }
        string View { get; set; }
        string[] Answer { get; set; }

        bool UserAnswerIsRight(string[] userAnswer);
    }
}
