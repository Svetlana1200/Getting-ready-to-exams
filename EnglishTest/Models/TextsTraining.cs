using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public class TextsTraining: ITraining
    {
        public TextsTraining(TaskService db, string level, ICondition condition) : base(db, level, condition)
        {
        }

        async public override Task CreateTasks()
        {
            var tasksId = await Database.GetTasksId("texts");
            var maxCount = 0;
            foreach (var taskId in tasksId)
            {
                Tasks[taskId] = "texts";
                maxCount += TextTask.MaxCount;
            }
            TasksId = new List<string>(Tasks.Keys);
            results = new Results(Tasks, maxCount);
        }
    }
}
