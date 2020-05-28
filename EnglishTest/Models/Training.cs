using System.Collections.Generic;

namespace EnglishTest.Models
{
    public abstract class Training
    {
        public ITrainingEndCondition Condition;
        public Parameters.Levels Level { get; set; }
        public Dictionary<string, string> Tasks = new Dictionary<string, string>();
        public List<string> TasksIds;
        public int СurrentIndex { get; set; }
        public string CurrentTaskId { get; set; }
        public string CurrentTaskCollection { get; set; }
        public bool IsCorrectLastTask = true;
        public Results Results;
        public int MaxCount;
        public bool isFinish;
        public bool wasAnsweredCurrentTask = true;

        public Training(Parameters.Levels level, ITrainingEndCondition condition)
        {
            Condition = condition;
            Level = level;
            СurrentIndex = 0;
        }

        public abstract void CreateTasks(TaskService db, int tasksNumber);

        public void AddTasks(TaskService db, string collection, int taskMaxCount, int tasksNumber)
        {
            var tasksIds = db.GetTasksIds(collection, tasksNumber);
            foreach (var taskId in tasksIds)
            {
                Tasks[taskId] = collection;
                MaxCount += taskMaxCount;
            }
        }

        public void ChangeCountCorrectOrIncorrectTasks(bool isCorrect, int count)
        {
            wasAnsweredCurrentTask = true;
            IsCorrectLastTask = isCorrect;
            Results.ChangeCountCorrectOrIncorrectTasks(isCorrect, CurrentTaskId, count);
            if (!isFinish)
                isFinish = Condition.IsFinish(Results);
        }

        public void MoveToNextTask()
        {
            if (СurrentIndex < Tasks.Count && !isFinish)
            {
                CurrentTaskId = TasksIds[СurrentIndex];
                CurrentTaskCollection = Tasks[CurrentTaskId];
                СurrentIndex++;
                wasAnsweredCurrentTask = false;
            }
        }
    }
}
