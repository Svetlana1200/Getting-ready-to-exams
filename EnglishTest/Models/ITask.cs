namespace EnglishTest.Models
{
    public interface ITask
    {
        string Id { get; set; }
        string View { get; set; }

        bool CheckUserAnswer(string userAnswer);
    }
}
