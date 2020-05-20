using System.Collections.Generic;

namespace EnglishTest.Models
{
    public class AllTasksTraining : Training
    {
        public AllTasksTraining(string level, int tasksNumber, ITrainingEndCondition condition) 
            : base(level, tasksNumber, condition) {}

        public override void CreateTasks(TaskService db)
        {
            AddTasks(db, "sentences", SentenceAnswer.MaxCount);
            AddTasks(db, "texts", TextAnswer.MaxCount);
            AddTasks(db, "images", ImageAnswer.MaxCount);

            TasksIds = new List<string>(Tasks.Keys);
            Results = new Results(Tasks, MaxCount);
            isFinish = Condition.IsFinish(Results);
        }
    }
}
