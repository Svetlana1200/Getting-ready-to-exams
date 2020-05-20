namespace EnglishTest.Models
{
    public class OneMistakeTrainingEndCondition : ITrainingEndCondition
    {
        public bool IsFinish(Results results)
        {
            foreach (var type in results.IncorrectTasks.Keys)
                if (results.IncorrectTasks[type] != 0)
                    return true;
            return false;
        }
    }
}
