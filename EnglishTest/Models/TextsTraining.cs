using System.Collections.Generic;

namespace EnglishTest.Models
{
    public class TextsTraining: Training
    {
        private readonly Dictionary<Parameters.Levels, string> collections = new Dictionary<Parameters.Levels, string>
        {
            { Parameters.Levels.B1, "texts" },
            { Parameters.Levels.B2, "texts2" }
        };
        public TextsTraining(Parameters.Levels level, ITrainingEndCondition condition) 
            : base(level, condition) {}

        public override void CreateTasks(TaskService db, int tasksNumber)
        {
            AddTasks(db, collections[Level], TextAnswer.MaxCount, tasksNumber);
            TasksIds = new List<string>(Tasks.Keys);
            Results = new Results(Tasks, MaxCount);
            isFinish = Condition.IsFinish(Results);
        }
    }
}
