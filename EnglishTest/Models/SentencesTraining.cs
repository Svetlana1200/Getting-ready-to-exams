using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public class SentencesTraining : ITraining
    {
        private readonly Dictionary<string, string> collections = new Dictionary<string, string>
        {
            { "B1", "sentences" },
            { "B2", "sentences2" }
        };

        public SentencesTraining(TaskService db, string level, ICondition condition) : base(db, level, condition)
        {
        }

        async public override Task CreateTasks()
        {
            var collection = collections[Level];
            var tasksId = await Database.GetTasksId(collection);
            var maxCount = 0;
            foreach (var taskId in tasksId)
            {
                Tasks[taskId] = collection;
                maxCount += SentenceTask.MaxCount;
            }
            TasksId = new List<string>(Tasks.Keys);
            results = new Results(Tasks, maxCount);
        }
    }
}
