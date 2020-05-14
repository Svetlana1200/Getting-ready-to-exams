using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public class AllTasksTraining : Training
    {
        public AllTasksTraining(TaskService db, string level, ITrainingEndCondition condition) : base(db, level, condition) {}

        public override void CreateTasks()
        {
            AddTasks("sentences", SentenceAnswer.MaxCount);
            AddTasks("texts", TextAnswer.MaxCount);
            AddTasks("images", ImageAnswer.MaxCount);

            TasksIds = new List<string>(Tasks.Keys);
            Results = new Results(Tasks, MaxCount);
            isFinish = Condition.isFinish(Results);
        }
    }
}
