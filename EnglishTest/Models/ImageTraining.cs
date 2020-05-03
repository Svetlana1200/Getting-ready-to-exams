using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public class ImageTraining : ITraining
    {
        public ImageTraining(TaskService db, string level, ICondition condition) : base(db, level, condition)
        {
        }

        async public override Task CreateTasks()
        {
            var tasksId = await Database.GetTasksId("images");
            var maxCount = 0;
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
