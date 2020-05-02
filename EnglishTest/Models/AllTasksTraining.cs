using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public class AllTasksTraining : ITraining
    {
        public AllTasksTraining(TaskService db, ICondition condition) : base(db, condition) 
        {
        }

        async public override Task CreateTasks()
        {
            var tasksId = await db.GetTasksId("sentences");
            var maxCount = 0;
            foreach (var taskId in tasksId)
            {
                Tasks[taskId] = "sentences";
                maxCount += SentenceTask.MaxCount;
            }
            tasksId = await db.GetTasksId("texts");
            foreach (var taskId in tasksId)
            {
                Tasks[taskId] = "texts";
                maxCount += TextTask.MaxCount;
            }
            tasksId = await db.GetTasksId("images");
            foreach (var taskId in tasksId)
            {
                Tasks[taskId] = "images";
                maxCount += ImageTask.MaxCount;
            }
            TasksId = new List<string>(Tasks.Keys);
            results = new Results(Tasks, maxCount);
        }
    }
}
