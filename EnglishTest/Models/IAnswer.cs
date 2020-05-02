namespace EnglishTest.Models
{
    public interface IAnswer
    {
        int Count { get; }
        bool IsRight();
    }
}
