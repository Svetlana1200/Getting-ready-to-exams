using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public class TextsTraining: Training
    {
        public TextsTraining(TaskService db, string level, ITrainingEndCondition condition) : base(db, level, condition) {}

        public override void CreateTasks()
        {
            AddTasks("texts", TextAnswer.MaxCount);
            TasksIds = new List<string>(Tasks.Keys);
            Results = new Results(Tasks, MaxCount);
            isFinish = Condition.isFinish(Results);
        }
    }
}
