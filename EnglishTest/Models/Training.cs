using System.Collections.Generic;

namespace EnglishTest.Models
{
    public class Training
    {
        public string Level { get; set; }
        public readonly Dictionary<string, string> Tasks;
        public readonly List<string> TasksId;
        public int СurrentIndex { get; set; }
        public string CurrentTaskId { get; set; }
        public string CurrentTaskCollection { get; set; }

        public Training(Dictionary<string, string> tasks)
        {
            СurrentIndex = 0;
            Tasks = tasks;
            TasksId = new List<string>(tasks.Keys);
        }

        public void MoveToNextTask()
        {
            if (СurrentIndex < Tasks.Count)
            {
                CurrentTaskId = TasksId[СurrentIndex];
                CurrentTaskCollection = Tasks[CurrentTaskId];
                СurrentIndex++;
            }
        }
    }
}
