using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public class TextsTraining: ITraining
    {
        public TextsTraining(TaskService db, ICondition condition) : base(db, condition)
        {
        }

        async public override Task CreateTasks()
        {
            var tasksId = await db.GetTasksId("texts");
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
