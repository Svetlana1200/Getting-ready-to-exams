using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public class AllTasksTraining : ITraining
    {
        public AllTasksTraining(TaskService db, string level, ICondition condition) : base(db, level, condition) 
        {
        }

        async public override Task CreateTasks()
        {
            var tasksId = await Database.GetTasksId("sentences");
            var maxCount = 0;
            foreach (var taskId in tasksId)
            {
                Tasks[taskId] = "sentences";
                maxCount += SentenceTask.MaxCount;
            }
            tasksId = await Database.GetTasksId("texts");
            foreach (var taskId in tasksId)
            {
                Tasks[taskId] = "texts";
                maxCount += TextTask.MaxCount;
            }
            tasksId = await Database.GetTasksId("images");
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
