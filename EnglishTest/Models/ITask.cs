namespace EnglishTest.Models
{
    public interface ITask
    {
        string Id { get; set; }
        string View { get; set; }
        string[] Answer { get; set; }
        int Points { get; set; }
    }
}
