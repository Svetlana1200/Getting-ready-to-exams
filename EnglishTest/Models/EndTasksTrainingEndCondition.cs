namespace EnglishTest.Models
{
    public class EndTasksTrainingEndCondition : ITrainingEndCondition
    {
        public bool IsFinish(Results results)
        {
            return false;
        }
    }
}
