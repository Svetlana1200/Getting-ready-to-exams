using System.Collections.Generic;

namespace EnglishTest.Models
{
    public class TextsTraining: Training
    {
        private readonly Dictionary<string, string> collections = new Dictionary<string, string>
        {
            { "B1", "texts" },
            { "B2", "texts2" }
        };
        public TextsTraining(string level, int tasksNumber, ITrainingEndCondition condition) 
            : base(level, tasksNumber, condition) {}

        public override void CreateTasks(TaskService db)
        {
            AddTasks(db, collections[Level], TextAnswer.MaxCount);
            TasksIds = new List<string>(Tasks.Keys);
            Results = new Results(Tasks, MaxCount);
            isFinish = Condition.IsFinish(Results);
        }
    }
}
