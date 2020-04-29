using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public abstract class ITraning
    {
        public readonly TaskService db;
        public readonly ICondition condition;
        public string Level { get; set; }
        public Dictionary<string, string> Tasks = new Dictionary<string, string>();
        public List<string> TasksId;
        public int СurrentIndex { get; set; }
        public string CurrentTaskId { get; set; }
        public string CurrentTaskCollection { get; set; }
        public bool isCorrectLastTask = true;

        public ITraning(TaskService db, ICondition condition)
        {
            this.db = db;
            this.condition = condition;
            СurrentIndex = 0;
            
        }
        public abstract Task CreateTasks();

        public bool IsFinish(bool isCorrectLastTask)
        {
            return condition.isFinish(isCorrectLastTask, DateTime.Now);
        }

        public void MoveToNextTask()
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
