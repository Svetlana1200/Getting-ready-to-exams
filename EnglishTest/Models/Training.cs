using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EnglishTest.Models
{
    public class Training
    {
        public string Level { get; set; }
        public readonly List<(string, Type)> Tasks = new List<(string, Type)>();
        public int СurrentIndex { get; set; }
        public string CurrentTask { get; set; }
        public Type CurrentTaskType { get; set; }

        public Training(List<ITask> tasks)
        {
            foreach (var task in tasks)
            {
                var stringTask = JsonConvert.SerializeObject(task);
                Tasks.Add((stringTask, task.GetType()));
            }
            СurrentIndex = -1;
        }

        [JsonConstructor]
        public Training(List<(string, Type)> tasks)
        {
            Tasks = tasks;
        }

        public void MoveToNextTask()
        {
            if (СurrentIndex < Tasks.Count)
            {
                СurrentIndex++;
                CurrentTask = Tasks[СurrentIndex].Item1;
                CurrentTaskType = Tasks[СurrentIndex].Item2;
            }
        }
    }
}
