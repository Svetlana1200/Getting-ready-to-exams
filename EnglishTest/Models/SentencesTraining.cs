using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnglishTest.Models
{
    public class SentencesTraining : Training
    {
        private readonly Dictionary<string, string> collections = new Dictionary<string, string>
        {
            { "B1", "sentences" },
            { "B2", "sentences2" }
        };

        public SentencesTraining(TaskService db, string level, ITrainingEndCondition condition) : base(db, level, condition) {}

        async public override Task CreateTasks()
        {
            await AddTasks(collections[Level], SentenceAnswer.MaxCount);
            TasksId = new List<string>(Tasks.Keys);
            Results = new Results(Tasks, MaxCount);
            isFinish = Condition.isFinish(Results);
        }
    }
}
