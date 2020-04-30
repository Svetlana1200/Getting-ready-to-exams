namespace EnglishTest.Models
{
    public interface ITask
    {
        string Id { get; set; }

        IAnswer CheckUserAnswer(string userAnswer);
    }
}
