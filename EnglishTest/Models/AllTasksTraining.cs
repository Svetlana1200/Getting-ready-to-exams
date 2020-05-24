using System.Collections.Generic;

namespace EnglishTest.Models
{
    public class AllTasksTraining : Training
    {
        private readonly Dictionary<Parameters.Levels, List<string>> collections = new Dictionary<Parameters.Levels, List<string>>
        {
            { Parameters.Levels.B1, new List<string>(){"sentences", "texts", "images" } },
            { Parameters.Levels.B2, new List<string>(){"sentences2", "texts2", "images" }  }
        };

        private readonly Dictionary<string, int> scoresForType = new Dictionary<string, int>
        {
            { "sentences", SentenceAnswer.MaxCount },
            { "sentences2", SentenceAnswer.MaxCount },
            { "texts", TextAnswer.MaxCount },
            { "texts2", TextAnswer.MaxCount },
            { "images", ImageAnswer.MaxCount },
            //{ "images2", ImageAnswer.MaxCount}
        };
        public AllTasksTraining(Parameters.Levels level, ITrainingEndCondition condition) 
            : base(level, condition) {}

        public override void CreateTasks(TaskService db, int tasksNumber)
        {
            foreach (var collection in collections[Level])
                AddTasks(db, collection, scoresForType[collection], tasksNumber);

            TasksIds = new List<string>(Tasks.Keys);
            Results = new Results(Tasks, MaxCount);
            isFinish = Condition.IsFinish(Results);
        }
    }
}
