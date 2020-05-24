using System.Collections.Generic;

namespace EnglishTest.Models
{
    public class SentencesTraining : Training
    {
        private readonly Dictionary<Parameters.Levels, string> collections = new Dictionary<Parameters.Levels, string>
        {
            { Parameters.Levels.B1, "sentences" },
            { Parameters.Levels.B2, "sentences2" }
        };

        public SentencesTraining(Parameters.Levels level, ITrainingEndCondition condition) 
            : base(level, condition) {}

        public override void CreateTasks(TaskService db, int tasksNumber)
        {
            AddTasks(db, collections[Level], SentenceAnswer.MaxCount, tasksNumber);
            TasksIds = new List<string>(Tasks.Keys);
            Results = new Results(Tasks, MaxCount);
            isFinish = Condition.IsFinish(Results);
        }
    }
}
