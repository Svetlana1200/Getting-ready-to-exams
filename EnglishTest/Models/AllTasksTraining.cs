using System.Collections.Generic;

namespace EnglishTest.Models
{
    public class AllTasksTraining : Training
    {
        private readonly Dictionary<string, List<string>> collections = new Dictionary<string, List<string>>
        {
            { "B1", new List<string>(){"sentences", "texts", "images" } },
            { "B2", new List<string>(){"sentences2", "texts2", "images" }  }
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
        public AllTasksTraining(string level, int tasksNumber, ITrainingEndCondition condition) 
            : base(level, tasksNumber, condition) {}

        public override void CreateTasks(TaskService db)
        {
            foreach (var collection in collections[Level])
                AddTasks(db, collection, scoresForType[collection]);

            TasksIds = new List<string>(Tasks.Keys);
            Results = new Results(Tasks, MaxCount);
            isFinish = Condition.IsFinish(Results);
        }
    }
}
