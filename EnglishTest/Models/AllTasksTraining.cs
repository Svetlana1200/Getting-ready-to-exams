using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public class AllTasksTraining : Training
    {
        public AllTasksTraining(TaskService db, string level, ITrainingEndCondition condition) : base(db, level, condition) {}

        async public override Task CreateTasks()
        {
            await AddTasks("sentences", SentenceAnswer.MaxCount);
            await AddTasks("texts", TextAnswer.MaxCount);
            await AddTasks("images", ImageAnswer.MaxCount);

            TasksId = new List<string>(Tasks.Keys);
            Results = new Results(Tasks, MaxCount);
            isFinish = Condition.isFinish(Results);
        }
    }
}
