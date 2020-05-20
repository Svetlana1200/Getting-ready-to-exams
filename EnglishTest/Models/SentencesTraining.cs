using System.Collections.Generic;

namespace EnglishTest.Models
{
    public class SentencesTraining : Training
    {
        private readonly Dictionary<string, string> collections = new Dictionary<string, string>
        {
            { "B1", "sentences" },
            { "B2", "sentences2" }
        };

        public SentencesTraining(string level, int tasksNumber, ITrainingEndCondition condition) 
            : base(level, tasksNumber, condition) {}

        public override void CreateTasks(TaskService db)
        {
            AddTasks(db, collections[Level], SentenceAnswer.MaxCount);
            TasksIds = new List<string>(Tasks.Keys);
            Results = new Results(Tasks, MaxCount);
            isFinish = Condition.IsFinish(Results);
        }
    }
}
