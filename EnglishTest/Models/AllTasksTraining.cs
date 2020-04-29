using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public class AllTasksTraining : ITraning
    {

        public AllTasksTraining(TaskService db, ICondition condition) : base(db, condition) 
        {
        }

        async public override Task CreateTasks()
        {
            var tasksId = await db.GetTasksId("sentences");
            foreach (var taskId in tasksId)
            {
                Tasks[taskId] = "sentences";
            }
            tasksId = await db.GetTasksId("texts");
            foreach (var taskId in tasksId)
            {
                Tasks[taskId] = "texts";
            }
            tasksId = await db.GetTasksId("images");
            foreach (var taskId in tasksId)
            {
                Tasks[taskId] = "images";
            }
            TasksId = new List<string>(Tasks.Keys);
        }
        public new bool IsFinish(bool isCorrectLastTask)
        {
            return condition.isFinish(isCorrectLastTask, DateTime.Now);
        }

        public new void MoveToNextTask()
        {
            if (СurrentIndex < Tasks.Count && !IsFinish(isCorrectLastTask))
            {
                CurrentTaskId = TasksId[СurrentIndex];
                CurrentTaskCollection = Tasks[CurrentTaskId];
                СurrentIndex++;
            }
        }
    }
}
