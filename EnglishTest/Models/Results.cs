using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public class Results
    {
        public readonly Dictionary<string, string> Tasks;
        public Dictionary<string, bool> IsCorrectTasksID = new Dictionary<string, bool>();
        public Dictionary<string, int> CorrectTasks = new Dictionary<string, int>();
        public Dictionary<string, int> IncorrectTasks = new Dictionary<string, int>();

        public Results(Dictionary<string, string> tasks)
        {
            Tasks = tasks;
        }
        public void ChangeCountCorrectOrIncorrectTasks(bool isCorrect, string taskId)
        {
            if (isCorrect)
            {
                IsCorrectTasksID[taskId] = true;
            }
            else
            {
                IsCorrectTasksID[taskId] = false;
            }
        }

        public void CreateResults()
        {
            foreach (var taskId in IsCorrectTasksID.Keys)
            {
                var type = Tasks[taskId];
                if (!CorrectTasks.ContainsKey(type))
                    CorrectTasks[type] = 0;
                if (!IncorrectTasks.ContainsKey(type))
                    IncorrectTasks[type] = 0;
                if (IsCorrectTasksID[taskId])
                    CorrectTasks[type] += 1;
                else
                    IncorrectTasks[type] += 1;

            }
        }
    }
}
