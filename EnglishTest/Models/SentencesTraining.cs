using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public class SentencesTraining : ITraining
    {
        public SentencesTraining(TaskService db, OneMistakeCondition condition) : base(db, condition)
        {
        }

        async public override Task CreateTasks()
        {
            var tasksId = await db.GetTasksId("sentences");
            foreach (var taskId in tasksId)
            {
                Tasks[taskId] = "sentences";
            }
            TasksId = new List<string>(Tasks.Keys);
        }
    }
}
