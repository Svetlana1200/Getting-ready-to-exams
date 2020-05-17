using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public abstract class Training
    {
        public readonly TaskService Database;
        public ITrainingEndCondition Condition;
        public string Level { get; set; }
        public Dictionary<string, string> Tasks = new Dictionary<string, string>();
        public List<string> TasksIds;
        public int СurrentIndex { get; set; }
        public string CurrentTaskId { get; set; }
        public string CurrentTaskCollection { get; set; }
        public bool IsCorrectLastTask = true;
        public Results Results;
        public int MaxCount;
        public bool isFinish;

        public Training(TaskService db, string level, ITrainingEndCondition condition)
        {
            Database = db;
            Condition = condition;
            Level = level;
            СurrentIndex = 0;
        }

        public abstract void CreateTasks();

        public void AddTasks(string collection, int taskMaxCount)
        {
            var tasksIds = Database.GetTasksIds(collection);
            foreach (var taskId in tasksIds)
            {
                Tasks[taskId] = collection;
                MaxCount += taskMaxCount;
            }
        }

        public void ChangeCountCorrectOrIncorrectTasks(bool isCorrect, int count)
        {
            IsCorrectLastTask = isCorrect;
            Results.ChangeCountCorrectOrIncorrectTasks(isCorrect, CurrentTaskId, count);
            if (!isFinish)
                isFinish = Condition.isFinish(Results);
        }

        public void MoveToNextTask()
        {
            if (СurrentIndex < Tasks.Count && !isFinish)
            {
                CurrentTaskId = TasksIds[СurrentIndex];
                CurrentTaskCollection = Tasks[CurrentTaskId];
                СurrentIndex++;
            }
        }
    }
}
