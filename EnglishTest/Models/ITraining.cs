using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public abstract class ITraining
    {
        public readonly TaskService Database;
        [NonSerialized] public ICondition Condition;
        public string Level { get; set; }
        public Dictionary<string, string> Tasks = new Dictionary<string, string>();
        public List<string> TasksId;
        public int СurrentIndex { get; set; }
        public string CurrentTaskId { get; set; }
        public string CurrentTaskCollection { get; set; }
        public bool IsCorrectLastTask = true;
        public Results Results;
        public int MaxCount;

        public ITraining(TaskService db, string level, ICondition condition)
        {
            Database = db;
            Condition = condition;
            Level = level;
            СurrentIndex = 0;
        }

        public void CreateResults()
        {
            Results.CreateResults();
        }

        public abstract Task CreateTasks();

        async public Task AddTasks(string collection, int taskMaxCount)
        {
            var tasksId = await Database.GetTasksId(collection);
            foreach (var taskId in tasksId)
            {
                Tasks[taskId] = collection;
                MaxCount += taskMaxCount;
            }
        }

        public bool IsFinish(bool isCorrectLastTask)
        {
            return Condition.isFinish(isCorrectLastTask, DateTime.Now);
        }

        public void ChangeCountCorrectOrIncorrectTasks(bool isCorrect, int count)
        {
            Results.ChangeCountCorrectOrIncorrectTasks(isCorrect, CurrentTaskId, count);
        }

        public void MoveToNextTask()
        {
            if (СurrentIndex < Tasks.Count && !IsFinish(IsCorrectLastTask))
            {
                CurrentTaskId = TasksId[СurrentIndex];
                CurrentTaskCollection = Tasks[CurrentTaskId];
                СurrentIndex++;
            }
        }
    }
}
