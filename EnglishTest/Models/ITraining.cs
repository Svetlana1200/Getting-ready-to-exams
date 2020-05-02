using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public abstract class ITraining
    {
        public readonly TaskService db;
        [NonSerialized] public ICondition condition;
        public string Level { get; set; }
        public Dictionary<string, string> Tasks = new Dictionary<string, string>();
        public List<string> TasksId;
        public int СurrentIndex { get; set; }
        public string CurrentTaskId { get; set; }
        public string CurrentTaskCollection { get; set; }
        public bool isCorrectLastTask = true;
        public Results results;

        public ITraining(TaskService db, ICondition condition)
        {
            this.db = db;
            this.condition = condition;
            СurrentIndex = 0;
        }

        public void CreateResults()
        {
            results.CreateResults();
        }

        public abstract Task CreateTasks();

        public bool IsFinish(bool isCorrectLastTask)
        {
            return condition.isFinish(isCorrectLastTask, DateTime.Now);
        }

        public void ChangeCountCorrectOrIncorrectTasks(bool isCorrect, int count)
        {
            results.ChangeCountCorrectOrIncorrectTasks(isCorrect, CurrentTaskId, count);
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
